using UnityEngine;
using UnityEditor;
using Models;
using Proyecto26;
using System.Collections.Generic;

public class MainScript : MonoBehaviour {

	private readonly string basePath = "https://jsonplaceholder.typicode.com";

	private void LogMessage(string title, string message) {
#if UNITY_EDITOR
		EditorUtility.DisplayDialog (title, message, "Ok");
#else
		Debug.Log(message);
#endif
	}

	public void Get(){

		// We can add default request headers for all requests
		RestClient.DefaultRequestHeaders["Authorization"] = "Bearer ...";

		RequestHelper requestOptions = null;

		RestClient.GetArray<Post>(basePath + "/posts").Then(res => {
			this.LogMessage ("Posts", JsonHelper.ArrayToJsonString<Post>(res, true));
			return RestClient.GetArray<Todo>(basePath + "/todos");
		}).Then(res => {
			this.LogMessage ("Todos", JsonHelper.ArrayToJsonString<Todo>(res, true));
			return RestClient.GetArray<User>(basePath + "/users");
		}).Then(res => {
			this.LogMessage ("Users", JsonHelper.ArrayToJsonString<User>(res, true));

			// We can add specific options and override default headers for a request
			requestOptions = new RequestHelper { 
				Uri = basePath + "/photos",
				EnableDebug = true,
				Headers = new Dictionary<string, string> {
					{ "Authorization", "Other token..." }
				}
			};
			return RestClient.GetArray<Photo>(requestOptions);
		}).Then(res => {
			this.LogMessage("Header", requestOptions.GetHeader("Authorization"));

			// And later we can clean the default headers for all requests
			RestClient.ClearDefaultHeaders();

		}).Catch(err => this.LogMessage ("Error", err.Message));
	}

	public void Post(){
		
		RestClient.Post<Post>(basePath + "/posts", new Post {
			title = "My first title",
			body = "My first message",
			userId = 26
		})
		.Then(res => this.LogMessage ("Success", JsonUtility.ToJson(res, true)))
		.Catch(err => this.LogMessage ("Error", err.Message));
	}

	public void Put(){

		RestClient.Put<Post>(new RequestHelper {
			Uri = basePath + "/posts/1",
			Body = new Post {
				title = "My new title",
				body = "My new message",
				userId = 26
			},
			Retries = 5,
			RetrySecondsDelay = 1,
			RetryCallback = (err, retries) => {
				Debug.Log(string.Format("Retry #{0} Status {1}\nError: {2}", retries, err.StatusCode, err));
			}
		}, (err, res, body) => {
			if(err != null){
				this.LogMessage ("Error", err.Message);
			}
			else{
				this.LogMessage ("Success", res.Text);
			}
		});
	}

	public void Delete(){

		RestClient.Delete(basePath + "/posts/1", (err, res) => {
			if(err != null){
				this.LogMessage ("Error", err.Message);
			}
			else{
				this.LogMessage ("Success", "Status: " + res.StatusCode.ToString());
			}
		});
	}
}

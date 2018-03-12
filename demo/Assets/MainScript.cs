using UnityEngine;
using UnityEditor;
using Models;
using Proyecto26;
using System.Collections.Generic;

public class MainScript : MonoBehaviour {

	private readonly string basePath = "https://jsonplaceholder.typicode.com";

	public void Get(){

		// We can add default request headers for all requests
		RestClient.DefaultRequestHeaders["Authorization"] = "Bearer ...";

		RequestHelper requestOptions = null;

		RestClient.GetArray<Post>(basePath + "/posts").Then(res => {
			EditorUtility.DisplayDialog ("Posts", JsonHelper.ArrayToJsonString<Post>(res, true), "Ok");
			return RestClient.GetArray<Todo>(basePath + "/todos");
		}).Then(res => {
			EditorUtility.DisplayDialog ("Todos", JsonHelper.ArrayToJsonString<Todo>(res, true), "Ok");
			return RestClient.GetArray<User>(basePath + "/users");
		}).Then(res => {
			EditorUtility.DisplayDialog ("Users", JsonHelper.ArrayToJsonString<User>(res, true), "Ok");


			// We can add specific options and override default headers for a request
			requestOptions = new RequestHelper { 
				url = basePath + "/photos",
				headers = new Dictionary<string, string> {
					{ "Authorization", "Other token..." }
				}
			};
			return RestClient.GetArray<Photo>(requestOptions);
		}).Then(res => {
			EditorUtility.DisplayDialog("Header", requestOptions.GetHeader("Authorization"), "Ok");

			// And later we can clean the default headers for all requests
			RestClient.CleanDefaultHeaders();

		}).Catch(err => EditorUtility.DisplayDialog ("Error", err.Message, "Ok"));
	}

	public void Post(){
		
		RestClient.Post<Models.Post>(basePath + "/posts", new Models.Post {
			title = "My first title",
			body = "My first message",
			userId = 26
		})
		.Then(res => EditorUtility.DisplayDialog ("Success", JsonUtility.ToJson(res, true), "Ok"))
		.Catch(err => EditorUtility.DisplayDialog ("Error", err.Message, "Ok"));
	}

	public void Put(){

		RestClient.Put<Post>(basePath + "/posts/1", new Models.Post {
			title = "My new title",
			body = "My new message",
			userId = 26
		}, (err, res, body) => {
			if(err != null){
				EditorUtility.DisplayDialog ("Error", err.Message, "Ok");
			}
			else{
				EditorUtility.DisplayDialog ("Success", JsonUtility.ToJson(body, true), "Ok");
			}
		});
	}

	public void Delete(){

		RestClient.Delete(basePath + "/posts/1", (err, res) => {
			if(err != null){
				EditorUtility.DisplayDialog ("Error", err.Message, "Ok");
			}
			else{
				EditorUtility.DisplayDialog ("Success", "Status: " + res.statusCode.ToString(), "Ok");
			}
		});
	}
}

using UnityEngine;
using UnityEditor;
using Models;
using Proyecto26.RestClient;

public class MainScript : MonoBehaviour {

	string basePath = "https://jsonplaceholder.typicode.com";

	public void Get(){

        RestClient.GetArray<Post>(basePath + "/posts").Then(res => {
            EditorUtility.DisplayDialog ("Success", JsonHelper.ArrayToJsonString<Post>(res, true), "Ok");
            return RestClient.GetArray<Todo>(basePath + "/todos");
		}).Then(res => {
            EditorUtility.DisplayDialog ("Success", JsonHelper.ArrayToJsonString<Todo>(res, true), "Ok");
            return RestClient.GetArray<User>(basePath + "/users");
		}).Then(res => {
            EditorUtility.DisplayDialog ("Success", JsonHelper.ArrayToJsonString<User>(res, true), "Ok");
		}).Catch(err => EditorUtility.DisplayDialog ("Error", err.Message, "Ok"));
	}

	public void Post(){
		
		RestClient.Post<Models.Post>(basePath + "/posts", new {
			title = "foo",
			body = "bar",
			userId = 1
		}, (err, res, body) => {
			if(err != null){
				EditorUtility.DisplayDialog ("Error", err.Message, "Ok");
			}
			else{
				EditorUtility.DisplayDialog ("Success", JsonUtility.ToJson(body, true), "Ok");
			}
		});
	}

	public void Put(){

        RestClient.Put<Post>(basePath + "/posts/1", new {
			title = "foo",
			body = "bar",
			userId = 1
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
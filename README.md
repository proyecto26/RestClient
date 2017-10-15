# RestClient for Unity 🤘

<img src="img/icono.png" width="150px" align="right" alt="Proyecto26.RestClient logo" />

This **HTTP/REST** Client is based on Promises to avoid the [Callback Hell](http://callbackhell.com/) ☠️ and the [Pyramid of doom](https://en.wikipedia.org/wiki/Pyramid_of_doom_(programming)) 💩 working with **Coroutines** in **Unity** 🎮, example:

```csharp
RestClient.GetArray<Post>(root + "/posts", (err, res) => {
  RestClient.GetArray<Todo>(root + "/todos", (errTodos, resTodos) => {
    RestClient.GetArray<User>(root + "/users", (errUsers, resUsers) => {
      if(err != null){
        EditorUtility.DisplayDialog ("Error", errTodos.Message, "Ok");
      }
    });
  });
});
```

But working with **Promises** we can improve our code, yay! 👏

```csharp
RestClient.GetArray<Post>(root + "/posts").Then(res => {
  EditorUtility.DisplayDialog ("Success", JsonHelper.ArrayToJson<Post>(res, true), "Ok");
  return RestClient.GetArray<Todo>(root + "/todos");
}).Then(res => {
  EditorUtility.DisplayDialog ("Success", JsonHelper.ArrayToJson<Todo>(res, true), "Ok");
  return RestClient.GetArray<User>(root + "/users");
}).Then(res => {
  EditorUtility.DisplayDialog ("Success", JsonHelper.ArrayToJson<User>(res, true), "Ok");
}).Catch(err => EditorUtility.DisplayDialog ("Error", err.Message, "Ok"));
```

## Demo ⏯
Do you want to see this beautiful package in action? Download the demo [here](https://minhaskamal.github.io/DownGit/#/home?url=https://github.com/proyecto26/RestClient/tree/master/demo)

![Demo](img/demo.png)

## Installation 👨‍💻
### Nuget package
Download this package from **NuGet** with **Visual Studio** creating a **NuGet.config** file at the root of your **Unity Project**, for example:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <config>
    <add key="repositoryPath" value=".\Assets\Packages" />
  </config>
</configuration>
```
The package to search for is **Proyecto26.RestClient**.

## Getting Started
The default methods **(GET, POST, PUT, DELETE)** are the following
```
RequestClient.Get("https://jsonplaceholder.typicode.com/posts/1").Then(res => {
  EditorUtility.DisplayDialog("Response", res, "Ok");
})

RequestClient.Post("https://jsonplaceholder.typicode.com/posts", newPost).Then(res => {
  EditorUtility.DisplayDialog("Status", res.statusCode.ToString(), "Ok");
})

RequestClient.Put("https://jsonplaceholder.typicode.com/posts/1", updatedPost).Then(res => {
  EditorUtility.DisplayDialog("Status", res.statusCode.ToString(), "Ok");
})

RequestClient.Delete("https://jsonplaceholder.typicode.com/posts/1").Then(res => {
  EditorUtility.DisplayDialog("Status", res.statusCode.ToString(), "Ok");
})
```

But we are going to create a class **"Post"** and the HTTP requests to load **JSON** data easily from the server
```
[Serializable]
public class Post
{
  public int id;

  public int userId;

  public string title;

  public string body;
}
```

* **GET JSON**
```
RequestClient.Get<Post>("https://jsonplaceholder.typicode.com/posts/1").Then(myPost => {
  EditorUtility.DisplayDialog("JSON", JsonUtility.ToJson(myPost, true), "Ok");
})
```
* **GET Array**
```
RequestClient.GetArray<Post>("https://jsonplaceholder.typicode.com/posts").Then(allPosts => {
  EditorUtility.DisplayDialog("JSON Array", JsonHelper.ArrayToJsonString<Post>(allPosts, true), "Ok");
})
```
* **POST**
```
RequestClient.Post<CustomMessage>("https://jsonplaceholder.typicode.com/posts", newPost).Then(customMessage => {
  EditorUtility.DisplayDialog("JSON", JsonUtility.ToJson(customMessage, true), "Ok");
})
```
* **PUT**
```
RequestClient.Get<CustomMessage>("https://jsonplaceholder.typicode.com/posts/1", updatedPost).Then(customMessage => {
  EditorUtility.DisplayDialog("JSON", JsonUtility.ToJson(customMessage, true), "Ok");
})
```

## Collaborators 🥇
[<img alt="jdnichollsc" src="https://avatars3.githubusercontent.com/u/2154886?v=3&s=117" width="117">](https://github.com/jdnichollsc) |
:---: |
[Nicholls](mailto:jdnichollsc@hotmail.com) |

## Credits 👍
* [Real Serious Games/C-Sharp-Promise](https://github.com/Real-Serious-Games/C-Sharp-Promise)

## Supporting 🍻
I believe in Unicorns 🦄
Support [me](http://www.paypal.me/jdnichollsc/2), if you do too.

## Happy coding 💯
Made with ❤️

<img width="150px" src="http://phaser.azurewebsites.net/assets/nicholls.png" align="right">

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/969f6b9d04324af58382f7ee7a8faccd)](https://www.codacy.com/app/jdnichollsc/RestClient?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=proyecto26/RestClient&amp;utm_campaign=Badge_Grade)
[![BCH compliance](https://bettercodehub.com/edge/badge/proyecto26/RestClient?branch=master)](https://bettercodehub.com/)
[![Build Status](https://travis-ci.org/proyecto26/RestClient.svg?branch=master)](https://travis-ci.org/proyecto26/RestClient)

# RestClient for Unity 🤘
> Supported Unity versions 2017.2 or higher

<img src="img/icono.png" width="150px" align="right" alt="Proyecto26.RestClient logo" />

This **HTTP/REST** Client is based on Promises to avoid the [Callback Hell](http://callbackhell.com/) ☠️ and the [Pyramid of doom](https://en.wikipedia.org/wiki/Pyramid_of_doom_(programming)) 💩 working with **Coroutines** in **Unity** 🎮, example:

```csharp
var api = "https://jsonplaceholder.typicode.com";
RestClient.GetArray<Post>(api + "/posts", (err, res) => {
  RestClient.GetArray<Todo>(api + "/todos", (errTodos, resTodos) => {
    RestClient.GetArray<User>(api + "/users", (errUsers, resUsers) => {
      //Missing validations to catch errors!
    });
  });
});
```

But working with **Promises** we can improve our code, yay! 👏

```csharp
RestClient.GetArray<Post>(api + "/posts").Then(response => {
  EditorUtility.DisplayDialog ("Success", JsonHelper.ArrayToJson<Post>(response, true), "Ok");
  return RestClient.GetArray<Todo>(api + "/todos");
}).Then(response => {
  EditorUtility.DisplayDialog ("Success", JsonHelper.ArrayToJson<Todo>(response, true), "Ok");
  return RestClient.GetArray<User>(api + "/users");
}).Then(response => {
  EditorUtility.DisplayDialog ("Success", JsonHelper.ArrayToJson<User>(response, true), "Ok");
}).Catch(err => EditorUtility.DisplayDialog ("Error", err.Message, "Ok"));
```

## Supported platforms
The [UnityWebRequest](https://docs.unity3d.com/Manual/UnityWebRequest.html) system supports most Unity platforms:

* All versions of the Editor and Standalone players
* WebGL
* Mobile platforms: iOS, Android
* Universal Windows Platform
* PS4 and PSVita
* XboxOne
* HoloLens
* Nintendo Switch

## Demo ⏯
Do you want to see this beautiful package in action? Download the demo [here](https://minhaskamal.github.io/DownGit/#/home?url=https://github.com/proyecto26/RestClient/tree/master/demo)

![Unity configuration](img/unity_demo.png)
![Demo](img/demo.png)

## Installation 👨‍💻

### Unity package
Download and install the **.unitypackage** file of the latest release published [here](https://github.com/proyecto26/RestClient/releases).

### Nuget package
Other option is download this package from **NuGet** with **Visual Studio** or using the **nuget-cli**, a **[NuGet.config](https://github.com/proyecto26/RestClient/blob/master/demo/NuGet.config)** file is required at the root of your **Unity Project**, for example:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <config>
    <add key="repositoryPath" value="./Assets/Packages" />
  </config>
</configuration>
```
The package to search for is **[Proyecto26.RestClient](https://www.nuget.org/packages/Proyecto26.RestClient/)**.

## Getting Started 📚
The default methods **(GET, POST, PUT, DELETE, HEAD)** are:
```csharp
RestClient.Get("https://jsonplaceholder.typicode.com/posts/1").Then(response => {
  EditorUtility.DisplayDialog("Response", response.Text, "Ok");
});
RestClient.Post("https://jsonplaceholder.typicode.com/posts", newPost).Then(response => {
  EditorUtility.DisplayDialog("Status", response.StatusCode.ToString(), "Ok");
});
RestClient.Put("https://jsonplaceholder.typicode.com/posts/1", updatedPost).Then(response => {
  EditorUtility.DisplayDialog("Status", response.StatusCode.ToString(), "Ok");
});
RestClient.Delete("https://jsonplaceholder.typicode.com/posts/1").Then(response => {
  EditorUtility.DisplayDialog("Status", response.StatusCode.ToString(), "Ok");
});
RestClient.Head("https://jsonplaceholder.typicode.com/posts").Then(response => {
  EditorUtility.DisplayDialog("Status", response.StatusCode.ToString(), "Ok");
});
```

And we have a generic method to create any type of request:
```csharp
RestClient.Request(new RequestHelper { 
  Uri = "https://jsonplaceholder.typicode.com/photos",
  Method = "POST",
  Timeout = 10000,
  Headers = new Dictionary<string, string> {
    { "Authorization", "Bearer JWT_token..." }
  },
  Body = newPost, //Content-Type: application/json
  BodyString = "Use it instead of 'Body' if you want to use other tool to serialize the JSON",
  SimpleForm = new Dictionary<string, string> {}, //Content-Type: application/x-www-form-urlencoded
  FormSections = new List<IMultipartFormSection>() {}, //Content-Type: multipart/form-data
  ChunkedTransfer = true,
  IgnoreHttpException = true, //Prevent to catch http exceptions
}).Then(response => {
  EditorUtility.DisplayDialog("Status", response.StatusCode.ToString(), "Ok");
});
```

With all the methods we have the possibility to indicate the type of response, in the following example we're going to create a class and the **HTTP** requests to load **JSON** data easily:
```csharp
[Serializable]
public class User
{
  public int id;
  public string name;
  public string username;
  public string email;
  public string phone;
  public string website;
}
```

* **GET JSON**
```csharp
var usersRoute = "https://jsonplaceholder.typicode.com/users"; 
RestClient.Get<User>(usersRoute + "/1").Then(firstUser => {
  EditorUtility.DisplayDialog("JSON", JsonUtility.ToJson(firstUser, true), "Ok");
});
```
* **GET Array (JsonHelper is an extension to manage arrays)**
```csharp
RestClient.GetArray<User>(usersRoute).Then(allUsers => {
  EditorUtility.DisplayDialog("JSON Array", JsonHelper.ArrayToJsonString<User>(allUsers, true), "Ok");
});
```

Also we can create different classes for custom responses:
```csharp
[Serializable]
public class CustomResponse
{
  public int id;
}
```
* **POST**
```csharp
RestClient.Post<CustomResponse>(usersRoute, newUser).Then(customResponse => {
  EditorUtility.DisplayDialog("JSON", JsonUtility.ToJson(customResponse, true), "Ok");
});
```
* **PUT**
```csharp
RestClient.Put<CustomResponse>(usersRoute + "/1", updatedUser).Then(customResponse => {
  EditorUtility.DisplayDialog("JSON", JsonUtility.ToJson(customResponse, true), "Ok");
});
```

## Custom HTTP Headers and Options 💥
**HTTP Headers**, such as `Authorization`, can be set in the **DefaultRequestHeaders** object for all requests
```csharp
RestClient.DefaultRequestHeaders["Authorization"] = "Bearer ...";
```

Also we can add specific options and override default headers for a request
```csharp
var currentRequest = new RequestHelper { 
  Uri = "https://jsonplaceholder.typicode.com/photos",
  Headers = new Dictionary<string, string> {
    { "Authorization", "Other token..." }
  }
};
RestClient.GetArray<Photo>(currentRequest).Then(response => {
  EditorUtility.DisplayDialog("Header", currentRequest.GetHeader("Authorization"), "Ok");
});

currentRequest.UploadProgress; //To know the progress by uploading data to the server
currentRequest.DownloadProgress; //To know the progress by downloading data from the server
currentRequest.Abort(); //Abort the request manually
```

And later we can clean the default headers for all requests
```csharp
RestClient.CleanDefaultHeaders();
```

### Example
- Unity
```csharp
[Serializable]
public class ServerResponse {
  public string id;
  public string date; //DateTime is not supported by JsonUtility
}
[Serializable]
public class User {
  public string firstName;
  public string lastName;
}
RestClient.Post<ServerResponse>("www.api.com/endpoint", new User {
  firstName = "Juan David",
  lastName = "Nicholls Cardona"
}).Then(response => {
  EditorUtility.DisplayDialog("ID: ", response.id, "Ok");
  EditorUtility.DisplayDialog("Date: ", response.date, "Ok");
});
```
- NodeJS as Backend (Using [Express](http://expressjs.com/es/starter/hello-world.html))
```js
router.post('/', function(req, res) {
  console.log(req.body.firstName)
  res.json({
    id: 123,
    date: new Date()
  })
});
```

## Collaborators 🥇
[<img alt="jdnichollsc" src="https://avatars3.githubusercontent.com/u/3436237?v=3&s=117" width="117">](https://github.com/diegoossa) | [<img alt="jdnichollsc" src="https://avatars3.githubusercontent.com/u/2154886?v=3&s=117" width="117">](https://github.com/jdnichollsc) |
:---: | :---: |
[Diego Ossa](mailto:diegoossa@gmail.com) | [Juan Nicholls](mailto:jdnichollsc@hotmail.com) |

## Credits 👍
* **Promises library for C#:** [Real Serious Games/C-Sharp-Promise](https://github.com/Real-Serious-Games/C-Sharp-Promise)

## Supporting 🍻
I believe in Unicorns 🦄
Support [me](http://www.paypal.me/jdnichollsc/2), if you do too.

## Happy coding 💯
Made with ❤️

<img width="150px" src="http://phaser.azurewebsites.net/assets/nicholls.png" align="right">

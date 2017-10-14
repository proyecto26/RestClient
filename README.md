# Proyecto26.RestClient

<img src="https://github.com/proyecto26/RestClient/blob/master/img/icono.png?raw=true" width="150px" align="right" alt="Proyecto26.RestClient logo" />

This HTTP/REST Client is based on Promises to avoid the [Callback Hell](http://callbackhell.com/) and the [Pyramid of doom](https://en.wikipedia.org/wiki/Pyramid_of_doom_(programming)) working with **Coroutines** in **Unity**, example:

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

But working with **Promises** we can improve our code, yay!

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

## Installation
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

## Collaborators
[<img alt="jdnichollsc" src="https://avatars3.githubusercontent.com/u/2154886?v=3&s=117" width="117">](https://github.com/jdnichollsc) |
:---: |
[Nicholls](mailto:jdnichollsc@hotmail.com) |

## Credits
* [Real Serious Games/C-Sharp-Promise](https://github.com/Real-Serious-Games/C-Sharp-Promise)

## Supporting
I believe in Unicorns 🦄
Support [me](http://www.paypal.me/jdnichollsc/2), if you do too.

## Happy coding
Made with <3

<img width="150px" src="http://phaser.azurewebsites.net/assets/nicholls.png" align="right">

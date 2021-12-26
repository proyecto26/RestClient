# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [2.6.2] - 2021-12-26

### Added
- Add a progress reporting callback by [@lyze237](https://github.com/lyze237) ([#153](https://github.com/proyecto26/RestClient/pull/153)).
- Add support for **PATCH** verb by [@neegool](https://github.com/neegool) ([#185](https://github.com/proyecto26/RestClient/pull/185)).
- Add solution to make network call on main thread by [@maifeeulasad](https://github.com/maifeeulasad) ([#190](https://github.com/proyecto26/RestClient/pull/190)).
- Add support for UPM package by [@benukhanov](https://github.com/benukhanov), [@tonygiang](https://github.com/tonygiang) and [@Hermesiss](https://github.com/Hermesiss) ([#198](https://github.com/proyecto26/RestClient/pull/198)).

### Changed
- Changes to use **RetryCallback** to handle token expiration by [@fegabe](https://github.com/fegabe) ([#142](https://github.com/proyecto26/RestClient/pull/142)).

### Fixed
- Handle HTTP NO CONTENT status code (204) to prevent null reference exceptions by [@L-Naej](https://github.com/L-Naej) and [@StevenGarberg](https://github.com/StevenGarberg) ([#188](https://github.com/proyecto26/RestClient/pull/188)).

### Removed
- Removing Depricated APIs by [@Drazail](https://github.com/Drazail) ([#164](https://github.com/proyecto26/RestClient/pull/164)).

## [2.6.1] - 2020-06-10

### Fixed
- Only retry when there is a network error by [@aang521](https://github.com/aang521) ([e8b6706](https://github.com/proyecto26/RestClient/commit/e8b670615c60f3925c75589c98717ec156bb64ab)).
- Fix new obsoletion warning in unity 2019.3 by [@extrawurst](https://github.com/extrawurst) ([6b8e92d](https://github.com/proyecto26/RestClient/commit/6b8e92df571119372400f768452148f2d59e71ee)).

## [2.6.0] - 2019-09-19

### Added
- Supporting retrieving a JSON Array from a POST request by [@Coeur](https://github.com/Coeur) ([7cc54bb](https://github.com/proyecto26/RestClient/pull/97/commits/7cc54bbbace4d5207efbb0b82de3a5d71aafc080)).
- Added Query string utilities ([e2fc36b](https://github.com/proyecto26/RestClient/commit/e2fc36b83cf72b6b730f5a39bdecd10db370948c)).

## [2.5.9] - 2019-09-08

### Added
- Add **ParseResponseBody** option to fix severe frame rate drop when parsing large response by [@TigerHix](https://github.com/TigerHix) ([47f8732](https://github.com/proyecto26/RestClient/pull/92/commits/47f8732f3468903779ac85b2dbfbfb12ce7abec1)).

## [2.5.7] - 2019-06-28

### Added
- Add default content type option to be able to disable JSON by default

## [2.5.5] - 2019-04-19

### Added
- Add try catch to prevent issues parsing JSON with JsonUtility

## [2.5.4] - 2019-04-18

### Fixed
- Fix issue with the default content type as JSON

## [2.5.3] - 2019-04-17

### Fixed
- Fix issue applying content type from headers and add new response property from exceptions

## [2.5.2] - 2019-01-23

### Added
- Add the missing properties of the UnityWebRequest system
- Add validations of the content-type to support WWWForm data

## [2.5.0] - 2019-01-21

### Added
- Add more UnityWebRequest properties and modify access modifiers to have more control

## [2.4.2] - 2019-01-14

### Fixed
- Support old versions of Unity

## [2.4.1] - 2019-01-10

### Fixed
- Fix critical issue with a recursive function

## [2.4.0] - 2019-01-10

### Added
- Add **EnableDebug** and **RetryCallback** properties from RequestHelper class to debug errors of the requests

## [2.3.0] - 2019-01-09

### Added
- Add **Retries** and **RetrySecondsDelay** property from RequestHelper to retry the requests

## [2.2.1] - 2019-01-02

### Added
- Add **ContentType** from **RequestHelper** class

## [2.2.0] - 2018-11-20

### Added
- Add **BodyRaw** property to the **RequestHelper** class to send raw data (byte) to the server directly

## [2.1.1] - 2018-08-26

### Fixed
- Fix exception when **DownloadHandler** is used to download large files

## [2.1.0] - 2018-08-23

### Added
- Add Support for a specific DownloadHandler

## [2.0.1] - 2018-07-27
### Fixed
- Update **RSG.Promise** package to support *dotnet Core 2* and **UWP**

## [2.0.0] - 2018-05-22

### Added
- Add more options to create HTTP requests.
- Added the BodyString property to have the possibility to use other tools to serialize the JSON
- Handle HTTP exceptions in a better way
- Using tools to improve the quality of the code
- And much more! 🎉🎉🎉

## [1.2.2] - 2018-03-04
### Added
- Added error validation (internet connection)

### Fixed
- Fixed issue destroying objects after change the scene
- Code review

## [1.2.1] - 2017-10-20

### Fixed
- Added **ResponseHelper** class for GET requests.
- Added **.unitypackage** to download and install the code from Unity.

## [1.2.0] - 2017-10-20

### Added
- Options per request
- DefaultRequestHeaders for all requests

## [1.0.1] - 2017-10-15

### Added
**Features:**
- Simple JSON Serialization.
- Get Arrays supported.
- HTTP Methods **(GET, POST, PUT, DELETE)**.
- Requests based on Promises.

**Supported Platforms:**
- All Unity platforms.

## [...1.0.1]
Missing tags for previous versions 🤷‍♂

[Unreleased]: https://github.com/proyecto26/RestClient/compare/v2.6.2...HEAD
[2.6.2]: https://github.com/proyecto26/RestClient/compare/v2.6.1...v2.6.2
[2.6.1]: https://github.com/proyecto26/RestClient/compare/v2.6.0...v2.6.1
[2.6.0]: https://github.com/proyecto26/RestClient/compare/v2.5.9...v2.6.0
[2.5.9]: https://github.com/proyecto26/RestClient/compare/2.5.7...v2.5.9
[2.5.7]: https://github.com/proyecto26/RestClient/compare/2.5.5...2.5.7
[2.5.5]: https://github.com/proyecto26/RestClient/compare/2.5.4...2.5.5
[2.5.4]: https://github.com/proyecto26/RestClient/compare/2.5.3...2.5.4
[2.5.3]: https://github.com/proyecto26/RestClient/compare/2.5.1...2.5.3
[2.5.2]: https://github.com/proyecto26/RestClient/compare/2.4.1...2.5.2
[2.5.0]: https://github.com/proyecto26/RestClient/compare/afa0148...debd33e
[2.4.2]: https://github.com/proyecto26/RestClient/compare/26d511e...afa0148
[2.4.1]: https://github.com/proyecto26/RestClient/compare/2.4.0...26d511e
[2.4.0]: https://github.com/proyecto26/RestClient/compare/2.3.0...2.4.0
[2.3.0]: https://github.com/proyecto26/RestClient/compare/2.2.0...2.3.0
[2.2.1]: https://github.com/proyecto26/RestClient/compare/2.2.0...86a7f55
[2.2.0]: https://github.com/proyecto26/RestClient/compare/2.1.1...2.2.0
[2.1.1]: https://github.com/proyecto26/RestClient/compare/2.1.0...2.1.1
[2.1.1]: https://github.com/proyecto26/RestClient/compare/2.1.0...2.1.1
[2.1.0]: https://github.com/proyecto26/RestClient/compare/2.0.1...2.1.0
[2.0.1]: https://github.com/proyecto26/RestClient/compare/2.0.0...2.0.1
[2.0.0]: https://github.com/proyecto26/RestClient/compare/1.2.2...2.0.0
[1.2.2]: https://github.com/proyecto26/RestClient/compare/1.2.1...1.2.2
[1.2.1]: https://github.com/proyecto26/RestClient/compare/1.2.0...1.2.1
[1.2.0]: https://github.com/proyecto26/RestClient/compare/1.0.1...1.2.0
[1.0.1]: https://github.com/proyecto26/RestClient/releases/tag/1.0.1
[...1.0.1]: https://github.com/proyecto26/RestClient/compare/fe7c32e...1.0.1

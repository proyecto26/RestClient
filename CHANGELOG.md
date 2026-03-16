# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [2.8.1] - 2026-03-16
### Fixed
- use nuget/setup-nuget action for NuGet CLI ([74a47b8](https://github.com/proyecto26/RestClient/commit/74a47b8d2a193b47d3b857ae35055e1aaada17fe)).




## [2.8.0] - 2026-03-16
### Changed
- v2.7.0 ([f64f226](https://github.com/proyecto26/RestClient/commit/f64f226a7dd8ce1461823cc7921d41a6e7e0cd30)).

### Fixed
- NuGet CLI install and NuGet branch split ([e149fcf](https://github.com/proyecto26/RestClient/commit/e149fcf2a4c3cc3bd6e8bb67083b9f14a8d66cf5)).
- remove secrets context from if condition (not allowed in expressions) ([b003fac](https://github.com/proyecto26/RestClient/commit/b003facf43297f3885a6d98be5a461f108305731)).
- proper .unitypackage build, NuGet CLI, UPM tagging ([95880e1](https://github.com/proyecto26/RestClient/commit/95880e1b6e6e8f7610e9aa981da07efbd15263ec)).
- add .unitypackage artifact to releases, clean up .gitignore ([a513b6b](https://github.com/proyecto26/RestClient/commit/a513b6bfafd210c485e1485c2e74000e28ee5655)).




## [2.7.0] - 2026-03-16
### Added
- add automated release workflow with semantic versioning ([f0d0cdd](https://github.com/proyecto26/RestClient/commit/f0d0cdd30d9833f1d0a7c3f712105c391f3dc012)).

### Changed
- [chores]: updated changelog w ref of #103; ([2f831dc](https://github.com/proyecto26/RestClient/commit/2f831dc323a2205235f5ecc18bea687d315617ac)).
- [version]: set to `2.6.3`; ([be566ca](https://github.com/proyecto26/RestClient/commit/be566ca2d6e881e892ae912fc78717e465e4ce2c)).
- [fix]: properly handle `ArgumentNullException` for abort controller;  - ref #103 ([a162b09](https://github.com/proyecto26/RestClient/commit/a162b094c2806f7e5ea8715469ca184001d8a848)).
- Update README.md ([1cfecf6](https://github.com/proyecto26/RestClient/commit/1cfecf6d6116d10982d86500b88ae3acdbc77faf)).
- added on production usage ([b6a44ab](https://github.com/proyecto26/RestClient/commit/b6a44ab880bb70194315409277ee2cdf72b29e2e)).
- added `maifeeulasad` to the list of contributors ([f93ab01](https://github.com/proyecto26/RestClient/commit/f93ab01a99aab5775ee10f28a70690bac8b407e5)).
- Fix HEAD promise method incorrectly calling DELETE ([ed1009d](https://github.com/proyecto26/RestClient/commit/ed1009d6b8486b343e0127e5babf70ae07109f4f)).
- Update demo project using NuGet package ([3cf90c1](https://github.com/proyecto26/RestClient/commit/3cf90c154c305c2db071b2f7efb0f29ba65395c1)).
- Updated Ci to restore to previous events ([5a5d5f6](https://github.com/proyecto26/RestClient/commit/5a5d5f60f17133176efcd82e6ba4fab41528f20c)).
- moved to Samples~ directory (as outlined by unity) ([2fcd8c3](https://github.com/proyecto26/RestClient/commit/2fcd8c38ffa4ece9c2d8cd33b32b85af85ba67eb)).
- Reverted package number to original one ([47f7514](https://github.com/proyecto26/RestClient/commit/47f75145abea90aae0bf40d2a234f56e0fae651c)).
- Added demo asmdef file and referenced the library ([97cb348](https://github.com/proyecto26/RestClient/commit/97cb3487d10b5027e47fea76404f36c76b23ad2a)).
- Meta file is needed. ([4ac0bdb](https://github.com/proyecto26/RestClient/commit/4ac0bdb8d47f722e9260a7a3db2de6ba130f5948)).
- meta file is needed ([8354073](https://github.com/proyecto26/RestClient/commit/835407353c454ba33e12c8863e94656f7716b12d)).
- Updated package ([2340197](https://github.com/proyecto26/RestClient/commit/2340197eaff841317a97e72012bf04b5a351b3de)).
- Added option to workflow dispatch an action ([56f75e6](https://github.com/proyecto26/RestClient/commit/56f75e621c7893a238180a2a43514111568143d4)).
- Updated name ([5ba63f9](https://github.com/proyecto26/RestClient/commit/5ba63f93d74675376cab42d10fa144623b4404ec)).
- Added assembly definition file ([3411773](https://github.com/proyecto26/RestClient/commit/34117739c1dded394a9c611d731c50b80ec35ef4)).
- Update ci.yml ([7589c39](https://github.com/proyecto26/RestClient/commit/7589c391be7a20c2ac474369af5eafd3f50df041)).
- Update Proyecto26.RestClient.nuspec ([bf26ad7](https://github.com/proyecto26/RestClient/commit/bf26ad7d44cb04a01a0e0bacfa8e79ed4d960fa5)).
- Update ci.yml ([c034e2c](https://github.com/proyecto26/RestClient/commit/c034e2cad29f7ec689ca28c645290fc911f93988)).
- Update README.md ([135badf](https://github.com/proyecto26/RestClient/commit/135badf8c7db1b6fc772b2ceaf2e643c21a7e493)).

### Fixed
- remove secrets context from if condition (not allowed in expressions) ([b003fac](https://github.com/proyecto26/RestClient/commit/b003facf43297f3885a6d98be5a461f108305731)).
- proper .unitypackage build, NuGet CLI, UPM tagging ([95880e1](https://github.com/proyecto26/RestClient/commit/95880e1b6e6e8f7610e9aa981da07efbd15263ec)).
- add .unitypackage artifact to releases, clean up .gitignore ([a513b6b](https://github.com/proyecto26/RestClient/commit/a513b6bfafd210c485e1485c2e74000e28ee5655)).




## [2.6.3] - 2025-11-22

### Fixed
- Fixed **ArgumentNullException** when calling `Abort()` or accessing properties on completed requests ([#103](https://github.com/proyecto26/RestClient/issues/103)).
- Enhanced disposal detection for UnityWebRequest objects to prevent crashes during cleanup scenarios.
- Added proper exception handling for all RequestHelper properties that access disposed UnityWebRequest instances.
- Improved thread safety for request cancellation in Unity's OnDestroy patterns.

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

[Unreleased]: https://github.com/proyecto26/RestClient/compare/v2.8.1...HEAD
[2.8.1]: https://github.com/proyecto26/RestClient/compare/v2.8.0...v2.8.1
[2.8.0]: https://github.com/proyecto26/RestClient/compare/v2.7.0...v2.8.0
[2.7.0]: https://github.com/proyecto26/RestClient/compare/v2.6.3...v2.7.0
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

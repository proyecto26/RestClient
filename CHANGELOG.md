# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [2.1.1] - 2018-08-26

### Fixed
- Fix exception when DownloadHandler is used to download large files

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

# Legerity page object generator CLI tool

[![GitHub release](https://img.shields.io/github/release/MADE-Apps/legerity.svg)](https://github.com/MADE-Apps/legerity/releases)
[![Build status](https://github.com/MADE-Apps/legerity/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/MADE-Apps/legerity/actions/workflows/ci.yml)
[![Twitter Followers](https://img.shields.io/twitter/follow/jamesmcroft?label=follow%20%40jamesmcroft&style=flat)](https://twitter.com/jamesmcroft)
[![.NET Tool](https://img.shields.io/nuget/v/Legerity.PageObjectGenerator)](https://www.nuget.org/packages/Legerity.PageObjectGenerator/)

Want to generate your Legerity page objects super fast? 🚀

The Legerity page object generator CLI tool allows you to auto-generate page objects for your Windows and Android application based on page files. (iOS and web coming soon!)

Just provide an input path, output path, and output namespace and you're away! 🤩

## Getting started

### Install the tool

```bash
dotnet tool install -g Legerity.PageObjectGenerator
```

**Or update an existing install**

```bash
dotnet tool update -g Legerity.PageObjectGenerator
```

### Run the tool

Once you have the tool installed, it is simply a case of running the CLI and providing the input, output, and namespace arguments.

```bash
legerity-pop -i "path/to/input/folder" -o "path/to/output/folder" -n "My.Namespace" -p "Windows"
```

This will read through all the page files that can be found under the input folder, generate a Legerity `BasePage` equivalent based on supported elements, and then drop those into your output folder. And that's it!

**Platform argument supports:** Windows / Android

## Contributing 🤝🏻

Contributions, issues and feature requests are welcome!

Feel free to check the [issues page](https://github.com/MADE-Apps/legerity/issues). You can also take a look at the [contributing guide](https://github.com/MADE-Apps/legerity/blob/main/CONTRIBUTING.md).

We actively encourage you to jump in and help with any issues, and if you find one, don't forget to log it!

## Support this project 💗

As many developers know, projects like Legerity are built and maintained in spare time. If you find this project useful, please **Star** the repo and if possible, [sponsor the project development on GitHub](https://github.com/sponsors/jamesmcroft).

## License

This project is made available under the terms and conditions of the [MIT license](https://github.com/MADE-Apps/legerity/blob/main/LICENSE).

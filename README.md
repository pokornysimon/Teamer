# Teamer

[![Build and deploy ASP.Net Core app to Azure Web App - ymcagenerator](https://github.com/pokornysimon/Teamer/actions/workflows/master_ymcagenerator.yml/badge.svg)](https://github.com/pokornysimon/Teamer/actions/workflows/master_ymcagenerator.yml)


Last released version is [here](https://ymcagenerator.azurewebsites.net/generator) (if you want to check it).

Purpose of this application is to generate different teams based on different rules which could be:
 - Members that must be together
 - Members that cannot be together
 - Members that cannot be together if they were together in last N years
 - Each team must/don't have to have a boy and girl (sorry, no more genders are supported now)

One of the purposes was to try the [Blazor Webassembly](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) system that was presented by Microsoft a few years ago.

# What you should know
 - Whole appliaction is in Czech language (no option to switch it now)
 - All conputation is done on the UI thread (no backend needed). Keep in mind that sometimes it could be slow.
 - Is is not the most optimal solution. Please don't hate me for front-end code, I know those mess should be separated in different files.
 - If you need to change the list of members (or history), you need to do it in code. I need this tool once a year, so no big deal for me.

# Documentação - Desafio Técnico - Stefanini Group - Robson Liesner de Lima Junior

## Instruções para executar a API RESTful com .NET 7 e MongoDB

- Instalar o Visual Studio 2022
- Instalar o C#
- Instalar o .NET SDK e runtime 7 e assim como o ASP.NET Core 7 - Shared Framework;
- Instalar o MondoDB Compass;
- Executar Visual Studio;
- Instalar via Nuget no projeto ChallengerStefaniniGroup.Core (Swashbuckle.AspNetCore (6.5.0), Microsoft.AspNetCore.OpenApi (7.0.14) e AutoMapper (13.0.1));
- Instalar via Nuget no projeto ChallengerStefaniniGroup.Data (Microsoft.EntityFrameworkCore (7.0.14));
- Instalar via Nuget no projeto ChallengerStefaniniGroup.Data (MongoDB.EntityFrameworkCore (7.0.0-preview.1)) ou executar o comando 'dotnet add package MongoDB.EntityFrameworkCore --version 7.0.0-preview.1';
- Em ChallengerStefaniniGroup.Core/appsettings.json/appsettings.Development.json colocar a url de conexão da sua base local (Ao executar o primerio Add vai ser criada a base automatica);

## Instruções para executar a interface de Usuário Vue.js

- Executar no Visual Studio Code
- Instalar o NPM
- Instalar via NPM (vue 3, vue-axios, vue-route@next, bootstrap, vue-sweetalert2);

## Escolhar Técnicas API RESTful com .NET 7 e MongoDB

- Separado por camadas (Core, Application, Data, Domain), cada camada com sua responsabilidade;
- Criado classes model AddTaskModel e UpdateTaskModel para modalagem das propriedades necessárias nos métodos Add e Put;
- Criado classe model TaskModel para resolução das propriedades que vão ser exibidas na View;
- Criado classe 'TaskStatusEnum' para padronização dos status disponíveis;
- Criado classe 'ExtensionEnum' para capturar do display definido na classe 'TaskStatusEnum';
- Criado RepositórioBase para generalização dos métodos comum com interface para herda a classe do repositório correspondente;
- Adicionado no escopo de serviço da aplicação interface e classe TaskService e assim como interface e classe TaskRepositorio;

- ## Escolhar Técnicas Interface Vue.js
...
Expliquei no vídeo, não tive tempo de descrever aqui..

# API de Exames
Feita em ASP.NET Core Web API, utilizando Entity Framework, AutoMapper, Pomelo, Scalar

## Como instalar o Entity Framework?

1. Abra o CMD do windows em qualquer local e execute o comando:

```bash
dotnet tool install --global dotnet-ef --version 9.0.0
```

## Como criar e remover as migrations?

1. Abra o CMD, e digita o seguinte comando para entrar no diretório do projeto:

```bash
cd diretorio_do_projeto/Exames.API
```

2. Execute o seguinte comando para criar as migrations

```bash
dotnet ef migrations add Initial
```

3. Execute o seguinte comando caso queira remover as migrations

```bash
dotnet ef migrations remove
```

## Como criar o banco de dados?

1. Dentro do projeto, abra o arquivo appsettings.json, e altere a conexão do banco de dados

```json
"ConnectionStrings" {
    "MySQL": "Server=localhost;DataBase=ExamesDB;Uid=SEU_USERNAME;Pwd=SUA_SENHA"
}
```

2. Abra o CMD, e digita o seguinte comando para entrar no diretório do projeto:

```bash
cd diretorio_do_projeto/Exames.API
```

3. Execute o seguinte comando para criar o banco de dados

```bash
dotnet ef database update
```

4. Execute o seguinte comando caso queira deletar o banco de dados

```bash
dotnet ef database drop
```

## Como rodar o projeto?

1. Dentro do Visual Studio 2022, deixe como http e execute o projeto

2. Acesse o link da documentação da API

```bash
http://localhost:xxxx/scalar    # Quando rodar o projeto, aparecerá o link e a porta da API
```
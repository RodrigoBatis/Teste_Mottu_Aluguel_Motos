# Teste Mottu - Sistema de Gerenciamento de Aluguel de Motos

Este projeto é um sistema de gerenciamento de aluguel de motos, que simplifica a locação de veículos e a administração de entregadores. Ele permite o cadastro e gerenciamento de informações sobre motos e entregadores, além de registrar locações e calcular valores associados.

## Funcionalidades
 - Moto cadastro e gerenciamento
 - Cadastro e gerenciamento de entregadores
 - Registro de locações de motos

## Tecnologias utilizadas
 - .NET
 - C#
 - PostgreSQL

# Como configurar o projeto

  1. Clone o repositório:
     ```sh
       git clone https://github.com/RodrigoBatis/Teste_Mottu_Aluguel_Motos.git
     ```
  3. Abra a solução no Visual Studio ou em um editor de código de sua preferência.
  4. Configure a conexão com o banco de dados PostgreSQL no arquivo appsettings.json.
     ```sh
        "ConnectionStrings": {
          "PostgreConnection": "Host=localhost;Database=DB_TESTE_MOTTU;Username={Adicionar UserName};Password={Adicionar Senha}"
        }
     ```
  6. Execute os seguintes comandos no Console do Gerenciador de Pacotes do Visual Studio para criar e atualizar o banco de dados:

     
     ```sh
       Add-Migration InitialCreate
     ```
     
     ```sh
       Update-Database
     ```
       
  7. Compile e execute o projeto.

# Endpoints e API

### A API expõe os seguintes endpoints:

## MOTOS
- **POST** -> `/api/motos` - Cadastra uma nova moto
- **GET** -> `/api/motos` - Retorna a lista de motos cadastradas
- **PUT** -> `/api/motos/{id}` - Atualiza o registro de uma moto
- **GET** -> `/api/motos/{id}` - Retorna os detalhes de uma moto
- **DELETE** -> `/api/motos/{id}` - Exclui uma moto

## ENTREGADORES
- **POST** -> `/api/entregadores` - Cadastra um novo entregador
- **GET** -> `/api/entregadores` - Retorna a lista de entregadores cadastrados
- **PUT** -> `/api/entregadores/{id}` - Atualiza os dados de um entregador
- **GET** -> `/api/entregadores/{id}` - Retorna os detalhes de um entregador
- **DELETE** -> `/api/entregadores/{id}` - Exclui um entregador
- **POST** -> `/api/entregadores/{id}/cnh` - Faz o upload da CNH de um entregador

## LOCAÇÕES
- **GET** -> `/api/locacoes` - Retorna a lista de locações registradas
- **POST** -> `/api/locacoes` - Registra uma nova locação
- **GET** -> `/api/locacoes/{id}` - Retorna os detalhes de uma locação
- **PUT** -> `/api/locacoes/{id}` - Atualiza os dados de uma locação
- **DELETE** -> `/api/locacao/{id}` - Exclui uma Locação








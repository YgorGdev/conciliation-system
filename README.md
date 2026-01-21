# Conciliation System

API de conciliação de eventos financeiros desenvolvida em .NET 8 com arquitetura em camadas, focada em organização das regras de negócio, testabilidade e evolução do projeto.

> Objetivo: estruturar o processo de conciliação separando domínio, aplicação e infraestrutura, evitando código acoplado e facilitando manutenção.

---

## ✨ Funcionalidades

- API REST para processamento de conciliações  
- Separação clara entre regras de negócio e infraestrutura  
- Validações centralizadas no domínio  
- Tratamento padronizado de erros  
- Logs de execução e rastreabilidade  

---

## 🧱 Arquitetura

Projeto organizado em camadas:

- **Conciliation.Api**  
  Camada de apresentação com controllers e endpoints HTTP.

- **Conciliation.Application**  
  Orquestração dos casos de uso e regras de aplicação.

- **Conciliation.Domain**  
  Regras de negócio, entidades e validações.

- **Conciliation.Infrastructure**  
  Integrações externas e persistência de dados.

---

## 🛠 Tecnologias utilizadas

- .NET 8  
- C#  
- REST API  
- Dependency Injection  
- Arquitetura em camadas (Clean/DDD inspired)

---

## ▶️ Como executar

### Pré-requisitos
- .NET SDK 8 instalado

### Rodando a aplicação

```bash
dotnet restore
dotnet build
dotnet run --project src/Conciliation.Api

A API será iniciada em:

http://localhost:5292


Se houver Swagger habilitado:

http://localhost:5292/swagger

📸 Evidências

Recomenda-se registrar:

Swagger com os endpoints

Terminal com a aplicação em execução

Exemplo de request/response no Postman

Estrutura do projeto em camadas

🚀 Próximos passos

Adicionar testes unitários

Implementar CI com GitHub Actions

Padronizar retornos com ProblemDetails

Melhorar observabilidade e logs

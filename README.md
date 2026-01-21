# Conciliation System

API de conciliação de eventos financeiros desenvolvida em .NET 8 com arquitetura em camadas, focada em organização das regras de negócio, confiabilidade dos dados e evolução contínua.

> Objetivo: estruturar o processo de conciliação separando domínio, aplicação e infraestrutura, garantindo baixo acoplamento, testabilidade e fácil expansão para novos provedores.

Projeto inspirado em cenários reais de fintech, onde diferentes fontes de transações precisam ser comparadas e validadas com segurança, auditabilidade e rastreabilidade.

---

## ✨ O que este projeto entrega

- API REST com endpoints para cadastro/consulta e execução da conciliação  
- Arquitetura em camadas (**Api / Application / Domain / Infrastructure**)  
- Regras de negócio isoladas no **Domain**  
- Persistência em **SQL Server**  
- Logs com **Serilog**  
- Documentação via **Swagger**

---

## 🧱 Arquitetura do projeto

- **Conciliation.Api**  
  Camada HTTP (endpoints, Swagger, configuração do host)

- **Conciliation.Application**  
  Casos de uso (orquestração do fluxo)

- **Conciliation.Domain**  
  Regras de negócio, entidades e validações (sem depender de banco)

- **Conciliation.Infrastructure**  
  Persistência e integrações (SQL Server, repositórios, etc.)

---

## 🔌 Endpoints (Swagger)

- `GET /health`  
- `POST /payments`  
- `GET /payments/{id}`  
- `POST /provider/transactions`  
- `POST /conciliation/run/{correlationId}`  

Swagger disponível em:
- `http://localhost:5292/swagger`

---

## 🛠 Tecnologias utilizadas

- .NET 8 (C#)  
- ASP.NET Core Web API  
- SQL Server  
- Entity Framework Core  
- Serilog  
- Swagger (OpenAPI)

---

## ▶️ Como executar

### Pré-requisitos
- .NET SDK 8  
- SQL Server (LocalDB, Express ou instância normal)

### 1) Configurar Connection String

No `appsettings.json` do projeto **Conciliation.Api**:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ConciliationDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
2) Subir o banco
dotnet ef database update --project src/Conciliation.Infrastructure --startup-project src/Conciliation.Api
3) Rodar a API
dotnet restore
dotnet build
dotnet run --project src/Conciliation.Api
API: http://localhost:5292

Swagger: http://localhost:5292/swagger

http://localhost:5292/swagger
📸 Evidências recomendadas
Swagger com os endpoints

Terminal com a aplicação em execução

Exemplo de request/response no Postman

Estrutura do projeto em camadas

🚀 Próximos passos
Adicionar testes unitários

Implementar CI com GitHub Actions

Padronizar retornos com ProblemDetails

Melhorar observabilidade e logs

Suporte a novos provedores de dados

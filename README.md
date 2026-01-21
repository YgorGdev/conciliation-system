# Conciliation System

API de conciliação de eventos financeiros desenvolvida em **.NET 8** com arquitetura em camadas e persistência em **SQL Server**. O foco é separar regras de negócio do resto do sistema, garantindo **manutenibilidade**, **testabilidade** e **evolução**.

> Inspirado em cenários reais de fintech, onde dados de pagamentos e transações de provedores precisam ser comparados e reconciliados com rastreabilidade.

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

🧪 Fluxo sugerido para testar
POST /payments

POST /provider/transactions

POST /conciliation/run/{correlationId}

GET /payments/{id}

📸 Evidências do projeto
Swagger – endpoints disponíveis

Response real da API

Aplicação em execução

Estrutura em camadas

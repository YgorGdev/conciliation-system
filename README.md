# Conciliation System (API + Domain + Application + Infrastructure)

Sistema de conciliação/validação de eventos financeiros (movimentações), com arquitetura em camadas e boas práticas para crescimento do projeto.

> Objetivo: transformar regras de conciliação e validação em um fluxo organizado, testável e extensível, evitando “código spaghetti” e facilitando evolução.

---

## ✨ Principais features

- **API REST** para iniciar/consultar conciliações
- **Arquitetura em camadas (Clean/DDD-like)**: Domain, Application, Infrastructure, API
- **Regras de negócio isoladas** no domínio (sem depender de banco/UI)
- **Validações e tratamento de erros** padronizados
- **Logs e rastreabilidade** do fluxo (pontos de conciliação / falhas / status)

---

## 🧱 Arquitetura do projeto

- **Conciliation.Api**  
  Camada de entrada (Controllers/Endpoints), validação de request, retornos HTTP.

- **Conciliation.Application**  
  Casos de uso (Use Cases/Services), orquestração do fluxo e DTOs.

- **Conciliation.Domain**  
  Regras de negócio puras (Entities, Value Objects, Domain Services, validações).

- **Conciliation.Infrastructure**  
  Acesso a dados e integrações (Repos, DbContext/ADO, providers externos, etc).

---

## 🛠️ Tecnologias e práticas utilizadas

- **.NET 8 (C#)**  
- **REST API**
- **Arquitetura em camadas (Clean Architecture / DDD-inspired)**
- **Dependency Injection**
- **Boas práticas de organização de código** (separação de responsabilidades, testes fáceis no domínio)

> Se você usou banco, fila ou cache, inclua aqui (SQL Server/PostgreSQL, RabbitMQ, etc).

---

## ▶️ Como rodar

### Pré-requisitos
- .NET SDK 8 instalado
- (Opcional) Docker, caso tenha banco/infra

### Rodando local
```bash
# restaurar dependências
dotnet restore

# build
dotnet build

# rodar API
dotnet run --project src/Conciliation.Api

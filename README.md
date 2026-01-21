# Conciliation System

API de conciliação de eventos financeiros desenvolvida em **.NET 8** com arquitetura em camadas, focada em organização das regras de negócio, confiabilidade dos dados e evolução contínua.

> Objetivo: estruturar o processo de conciliação separando domínio, aplicação e infraestrutura, garantindo baixo acoplamento, testabilidade e fácil expansão para novos provedores.

Projeto inspirado em cenários reais de fintech, onde diferentes fontes de transações precisam ser comparadas e validadas com segurança, auditabilidade e rastreabilidade.

---

## ✨ Funcionalidades

- API REST para processamento de conciliações  
- Separação clara entre regras de negócio e infraestrutura  
- Validações centralizadas no domínio  
- Tratamento padronizado de erros  
- Logs de execução e rastreabilidade  
- Extensível para múltiplos provedores  
- Regras de negócio independentes da camada de API  
- Base preparada para testes automatizados

---

## 🧱 Arquitetura

Projeto organizado em camadas:

- **Conciliation.Api**  
  Camada de apresentação com controllers e endpoints HTTP.

- **Conciliation.Application**  
  Orquestração dos casos de uso e regras de aplicação.

- **Conciliation.Domain**  
  Regras de negócio, entidades e validações, sem dependência de infraestrutura.

- **Conciliation.Infrastructure**  
  Integrações externas e persistência de dados.

### Fluxo simplificado

1. Recebimento das transações do provedor  
2. Validação pelas regras do domínio  
3. Processamento da conciliação  
4. Geração do resultado e disponibilização via API

---

## 🛠 Tecnologias utilizadas

- .NET 8  
- C#  
- REST API  
- Dependency Injection  
- Logging estruturado  
- Arquitetura em camadas (Clean/DDD inspired)  
- Organização preparada para CI/CD

---

## ▶️ Como executar

### Pré-requisitos
- .NET SDK 8 instalado

### Rodando a aplicação

```bash
dotnet restore
dotnet build
dotnet run --project src/Conciliation.Api

###

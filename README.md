# 🚀 Stoqa - Microsserviços

![Badge](https://img.shields.io/badge/Status-Em%20Desenvolvimento-blue)

## 📌 Sobre o Projeto

O **Stoqa** é um projeto de estudo voltado para entender os conceitos de microsserviços, incluindo:

- **Unit of Work (UoW)**
- **Notification Pattern**
- **Code First**
- **Migrations**
- **Mensageria com RabbitMQ**

A arquitetura do projeto **não segue o padrão de eventos**, pois o foco é explorar outras abordagens fundamentais em microsserviços.

## 🛠️ Tecnologias Utilizadas

🔹 **.NET 8** - Plataforma principal do projeto  
🔹 **Entity Framework Core** - ORM para acesso ao banco de dados usando Code First  
🔹 **Polly** - Estratégia de resiliência para tentativas de conexão com a mensageria  
🔹 **RabbitMQ.Client** - Biblioteca para comunicação com a mensageria  
🔹 **FluentValidation** - Framework para validação de dados  
🔹 **SQL Server** - Banco de dados relacional  

---

## 📂 Estrutura do Projeto

O projeto é dividido em diferentes microsserviços, cada um responsável por uma parte específica do sistema:

### 🏷️ Stoqa.Product
📌 Gerencia tudo relacionado a **produtos** e **itens no estoque**.

### 📦 Stoqa.Order
📌 Responsável pelo **gerenciamento de ordens**, incluindo criação, atualização e rastreamento de pedidos.

### 👥 Stoqa.Managment
📌 Cuida do **gerenciamento de usuários** e suas permissões no sistema.

### 🔐 Stoqa.Identity
📌 Serviço de **autenticação e autorização**, utilizando **ASP.NET Identity** para gerenciar credenciais e permissões.

---

## ▶️ Como Executar o Projeto

### 🔧 Pré-requisitos
Antes de executar o projeto, certifique-se de ter os seguintes componentes instalados:

✅ **.NET 8 SDK**  
✅ **Docker** *(para rodar RabbitMQ e SQL Server)*  
✅ **SQL Server** *(caso prefira rodar localmente)*  
✅ **RabbitMQ**  

### 📌 Rodando Banco de Dados e Mensageria

Se estiver usando **Docker**, pode subir os serviços necessários com o seguinte comando:

```sh
docker-compose up -d
```

Caso não tenha um arquivo `docker-compose.yml`, você pode iniciar os serviços manualmente:

```sh
# Subir o RabbitMQ
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management

# Subir o SQL Server
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourStrong!Passw0rd' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
```

### 📌 Executando os Microsserviços

Cada serviço pode ser executado individualmente:

```sh
cd Stoqa.Product && dotnet run
cd ../Stoqa.Order && dotnet run
cd ../Stoqa.Managment && dotnet run
cd ../Stoqa.Identity && dotnet run
```

---

## 🔥 Próximos Passos

- ✅ Implementar **testes unitários e de integração**  
- ✅ Adicionar **microsserviço de pagamento**  
- ✅ Melhorar a **fluxo de conferência**  
- ✅ Implementar um **API Gateway com YARP**  

---

## 🤝 Contribuição
Este é um projeto de estudo, mas se quiser contribuir, fique à vontade para abrir **issues** e **pull requests**! 

💡 **Sugestões são bem-vindas!**

---

## 📜 Licença
Este projeto está sob a licença **MIT**. Sinta-se à vontade para usá-lo e modificá-lo conforme necessário. 

---

🚀 **Vamos construir juntos!**


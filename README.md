# 🚀 Stoqa - Microsserviços

![Badge](https://img.shields.io/badge/Status-Em%20Desenvolvimento-blue)

## 📌 Sobre o Projeto

O **Stoqa** é um projeto de estudo voltado para entender os conceitos de microsserviços, incluindo:

- **Unit of Work (UoW)**
- **Notification Pattern**
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

### 🔐 Stoqa.UserAccess
📌 Serviço de **autenticação e autorização**, utilizando **ASP.NET Identity** para gerenciar credenciais e permissões.

---

## ▶️ Como Executar o Projeto

### 🔧 Pré-requisitos
Antes de executar o projeto, certifique-se de ter os seguintes componentes instalados:

✅ **.NET 8 SDK**  
✅ **Docker** *(para rodar RabbitMQ, SQL Server, Postgre e as APIs)*  
✅ **SQL Server** *(caso prefira rodar localmente)*
✅ **Postgre** *(caso prefira rodar localmente)*  
✅ **RabbitMQ**  

### 📌 Rodando o Sistema com Docker Compose

O projeto já inclui um arquivo `docker-compose.yml` para facilitar a inicialização de todos os serviços. Basta executar o comando:

```sh
docker-compose up -d
```

Isso irá iniciar automaticamente:

✅ **RabbitMQ**  
✅ **SQL Server**  
✅ **Todos os Microsserviços (APIs)**  

Caso precise reiniciar ou parar os serviços:

```sh
# Para parar todos os serviços
docker-compose down

# Para reiniciar
docker-compose up -d --build
```
---

## 🔥 Próximos Passos

- ✅ Implementar **testes unitários e de integração**  
- ✅ Implementar **microsserviço de pagamento**   
- ✅ Implementar um **API Gateway com YARP**
- ✅ Adicionat **integração com envio de email**    

---

## 🤝 Contribuição
Este é um projeto de estudo, mas se quiser contribuir, fique à vontade para abrir **issues** e **pull requests**! 

💡 **Sugestões são bem-vindas!**

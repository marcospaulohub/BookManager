# 📚 BookManager

**BookManager** é um sistema de gerenciamento de biblioteca desenvolvido em .NET, com arquitetura em camadas e separação clara de responsabilidades. O sistema permite o cadastros de livros, autores e usuários, bem como pelo controle de empréstimos de livros, com regras específicas de tempo e renovação..

## 🧠 Lógica de Negócio

### 🔸 Entidades Principais

#### **Autor** / **Author**
- Campos: `Id`, `Name`, `Nationality`,`BirthDate`,`DeathDate`,`Biography`, `OfficialWebsite`, `Books`.
- Regras:
  - Um autor pode estar vinculado a vários livros.

#### **Livro** / **Book**
- Campos: `Id`, `Title`, `ISBN`, `PublicationDate`,`Authors`.
- Regras:
  - Um livro pode ter um ou mais autores.
  - Um livro pode ser emprestado a apenas um usuário por vez.
  - Um livro só pode ser emprestado novamente após devolução ou renovação não pendente.

#### **Usuário** / **User**
- Campos: `Id`, `Name`, `Email`,`Loans`.
- Regras:
  - Usuários devem estar cadastrados para realizar empréstimos.
  - Um usuário pode ter vários livros emprestados simultaneamente, desde que estejam dentro do prazo.

#### **Empréstimo** / **Loan**
- Campos: `Id`, `UserId`, `BookId`, `Book`, `LoanDate`,`ReturnDate`.
- Regras:
  - Cada empréstimo tem duração padrão de **14 dias**.
  - Se a data de devolução cair em um fim de semana, ela será automaticamente ajustada para o próximo dia útil.
  - Pode ser **renovado** antes do vencimento com no mínimo **7 dias** após a data do empréstimo.
  - Não é possível emprestar um livro que já está emprestado.
  - Usuários com empréstimos vencidos não podem realizar novos empréstimos.

---

## 🔄 Relacionamentos

- **Livro ↔ Autor**: muitos-para-muitos.
- Essa relação é gerenciada por uma tabela intermediária (`BookAuthor`).

---

## 📋 Regras de Negócio

### ✅ Cadastro
- Autores e livros podem ser cadastrados por administradores.
- Um livro deve sempre estar associado a pelo menos um autor.

### 📦 Empréstimos
- Somente usuários cadastrados podem emprestar livros.
- Duração padrão: **14 dias**.
- Após esse período, o livro deve ser devolvido ou o empréstimo deve ser renovado.

### 🔁 Renovação
- Permitida se solicitada **antes da data de vencimento** com no mínimo **7 dias** após a data do empréstimo.
- O prazo é estendido por mais **14 dias**.
- Pode haver limite de renovações (definido conforme a política do sistema).

### 📤 Devolução
- Deve ser feita até a data prevista.
- O sistema registra a `ReturnDate`.
- Após devolução, o livro se torna disponível para novos empréstimos.

---

## 📎 Exemplo de Fluxo

1. Um usuário cadastrado solicita um livro disponível.
2. O sistema registra o empréstimo com data prevista de devolução (**14 dias**).
3. Antes do vencimento, o usuário pode renovar o empréstimo.
4. Ao devolver o livro, o sistema atualiza o status e libera o livro para novo empréstimo.


## 🧱 Estrutura do Projeto

O projeto está dividido nos seguintes módulos:

- **BookManager.API**: Camada de exposição (Web API).
- **BookManager.App**: Camada de aplicação com regras de negócio.
- **BookManager.Core**: Contém as entidades, interfaces, valueObjects e contratos de domínio.
- **BookManager.Infra**: Implementações de persistência de dados.
- **BookManager.Test**: Projeto de testes unitários e de integração.



## 🚀 Tecnologias Utilizadas

- **.NET 8**: Framework principal para o desenvolvimento da aplicação.
- **Padrão Repository**: Padrão que abstrai o acesso aos dados, centralizando as operações em um repositório.
- **Padrão Result**: Padrão que define uma forma explícita e clara de expressar erros no código.
- **xUnit**: Framework de testes unitários utilizado para garantir a qualidade do código.
- **Entity Framework Core**: ORM (Object-Relational Mapper) utilizado para comunicação com o banco de dados.
- **SQL Server**: Banco de dados relacional.

## ⚙️ Funcionalidades

|      | Funcionalidades               |
|------| ----------------------------- |
|  ✅ | Cadastro de autores            |
|  ✅ | Cadastro de livros             |
|  ✅ | Relacionamento entre autores e livros |
|  ✅ | Registro de usuários           |
|  ✅ | Empréstimo de livros           |
|  ❌ | Devolução de livros            |
|  ❌ | Histórico de empréstimos       |


## 📦 Como Executar o Projeto

1. Clone este repositório:
   ```bash
   git clone https://github.com/seu-usuario/BookManager.git
   ```
2. Navegue até a pasta do projeto:
   ```bash
   cd BookManager
   ```
3. Configure o banco de dados (opcional: `appsettings.json`)
4. Execute a aplicação:
   ```bash
   dotnet run --project BookManager.API
   ```

## 🧪 Executando os Testes

```bash
dotnet test BookManager.Test
```

## ✍️ Autor

Desenvolvido por [Marcos Paulo](https://github.com/marcospaulohub).  
Sinta-se à vontade para contribuir!

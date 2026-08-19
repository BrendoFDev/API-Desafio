# Desafio Técnico — API de Concessionária de Carros

## Sobre o desafio

O objetivo deste desafio é desenvolver uma **API REST para gerenciamento de uma concessionária de veículos**.

A aplicação deverá permitir o cadastro e gerenciamento de **carros, clientes e reservas**, respeitando as regras de negócio descritas neste documento.

O desafio tem como objetivo avaliar a capacidade de transformar requisitos de negócio em uma solução funcional, organizada e consistente.

A escolha da arquitetura, bibliotecas, padrões e ferramentas fica a critério do desenvolvedor, desde que os requisitos definidos neste documento sejam atendidos.

---

# Domínio da aplicação

A aplicação deverá trabalhar com três entidades principais:

## Carro

Representa um veículo disponível na concessionária.

Campos obrigatórios:

* Marca
* Modelo
* Ano de fabricação
* Cor
* Valor

---

## Cliente

Representa um cliente da concessionária.

Campos obrigatórios:

* Nome
* CPF
* Data de criação

---

## Reserva

Representa uma reserva de um carro realizada por um cliente.

Uma reserva deverá possuir:

* Cliente
* Carro
* Dia da reserva

O relacionamento esperado é:

```text
Cliente
   │
   │ 1:N
   ▼
Reserva
   ▲
   │ N:1
   │
Carro
```

Uma reserva deve sempre estar vinculada a **um cliente existente** e **um carro existente**.

---

# Requisitos funcionais

## 1. Cadastro de carros

Deve existir um endpoint responsável por cadastrar um novo carro.

Todos os campos do carro são obrigatórios.

Exemplo de requisição:

```http
POST /api/carros
```

```json
{
  "marca": "Toyota",
  "modelo": "Corolla",
  "anoFabricacao": 2025,
  "cor": "Prata",
  "valor": 150000.00
}
```

A API deverá validar os dados antes de realizar o cadastro.

---

## 2. Consulta de carros

Deve existir um endpoint para consultar os carros cadastrados.

A consulta deverá obrigatoriamente possuir **paginação**.

Também deverão estar disponíveis os seguintes filtros:

* Marca
* Modelo
* Ano de fabricação
* Cor

Os filtros deverão ser opcionais e poderão ser combinados.

Exemplo:

```http
GET /api/carros?page=1&pageSize=10
```

Com filtros:

```http
GET /api/carros?page=1&pageSize=10&marca=Toyota&modelo=Corolla&anoFabricacao=2025&cor=Prata
```

A resposta deverá disponibilizar informações suficientes para o consumidor da API entender a paginação, como:

* Página atual;
* Quantidade de registros por página;
* Quantidade total de registros;
* Quantidade total de páginas;
* Registros retornados.

---

## 3. Atualização de carro

Deve existir um endpoint para atualizar um carro específico.

Exemplo:

```http
PUT /api/carros/{id}
```

```json
{
  "marca": "Toyota",
  "modelo": "Corolla XEi",
  "anoFabricacao": 2025,
  "cor": "Preto",
  "valor": 155000.00
}
```

A API deverá verificar se o carro informado existe antes de realizar a atualização.

---

## 4. Remoção de carro

Deve existir um endpoint para remover um carro específico.

Exemplo:

```http
DELETE /api/carros/{id}
```

### Regra de negócio

Um carro **não poderá ser removido caso possua uma reserva vinculada a ele**.

A API deverá impedir a operação e retornar uma resposta HTTP adequada informando o motivo.

---

# Clientes

## 5. Cadastro de cliente

Deve existir um endpoint para cadastrar um novo cliente.

Todos os dados do cliente são obrigatórios.

Exemplo:

```http
POST /api/clientes
```

```json
{
  "nome": "João da Silva",
  "cpf": "12345678900",
  "dataCriacao": "2026-08-19T14:00:00"
}
```

---

## 6. Atualização de cliente

Deve existir um endpoint para atualizar um cliente específico.

Exemplo:

```http
PUT /api/clientes/{id}
```

```json
{
  "nome": "João da Silva Santos",
  "cpf": "12345678900"
}
```

A API deverá verificar se o cliente existe antes de realizar a atualização.

---

## 7. Remoção de cliente

Deve existir um endpoint para remover um cliente específico.

Exemplo:

```http
DELETE /api/clientes/{id}
```

### Regra de negócio

Um cliente **não poderá ser removido caso possua uma reserva vinculada a ele**.

A API deverá impedir a operação e retornar uma resposta HTTP adequada informando o motivo.

---

# Reservas

## 8. Reserva de um carro

Deve existir um endpoint que permita realizar a reserva de um carro para um cliente específico.

A reserva deverá receber:

* Identificador do cliente;
* Identificador do carro;
* Dia da reserva.

Exemplo:

```http
POST /api/reservas
```

```json
{
  "clienteId": 1,
  "carroId": 10,
  "diaReserva": "2026-08-25"
}
```

A API deverá validar se:

* O cliente existe;
* O carro existe;
* Os dados enviados são válidos.

---

# Regras de negócio

A implementação deverá respeitar, no mínimo, as seguintes regras:

### Carros

* Todos os campos do carro são obrigatórios no cadastro.
* Um carro inexistente não pode ser atualizado.
* Um carro inexistente não pode ser removido.
* Um carro que possua reserva não pode ser removido.

### Clientes

* Todos os campos do cliente são obrigatórios no cadastro.
* Um cliente inexistente não pode ser atualizado.
* Um cliente inexistente não pode ser removido.
* Um cliente que possua reserva não pode ser removido.

### Reservas

* Uma reserva deve obrigatoriamente estar vinculada a um cliente.
* Uma reserva deve obrigatoriamente estar vinculada a um carro.
* O cliente informado deve existir.
* O carro informado deve existir.

### Consultas

* A consulta de carros deve possuir paginação.
* Os filtros de marca, modelo, ano de fabricação e cor devem ser opcionais.
* Os filtros devem poder ser utilizados simultaneamente.
* A ausência de resultados deve ser tratada adequadamente.

---

# Endpoints obrigatórios

A API deverá disponibilizar, no mínimo, os seguintes recursos:

| Método   | Endpoint             | Descrição                                |
| -------- | -------------------- | ---------------------------------------- |
| `POST`   | `/api/carros`        | Cadastrar carro                          |
| `GET`    | `/api/carros`        | Consultar carros com paginação e filtros |
| `PUT`    | `/api/carros/{id}`   | Atualizar carro                          |
| `DELETE` | `/api/carros/{id}`   | Remover carro                            |
| `POST`   | `/api/clientes`      | Cadastrar cliente                        |
| `PUT`    | `/api/clientes/{id}` | Atualizar cliente                        |
| `DELETE` | `/api/clientes/{id}` | Remover cliente                          |
| `POST`   | `/api/reservas`      | Criar reserva                            |

A estrutura das rotas fica como referência. Caso seja utilizada uma convenção diferente, ela deverá permanecer consistente em toda a API.

---

# Requisitos técnicos

A aplicação deverá ser desenvolvida como uma **API REST**.

Não é obrigatório utilizar uma arquitetura específica.

O candidato deverá tomar as decisões técnicas necessárias para construir uma aplicação organizada e de fácil manutenção.

A solução deverá demonstrar preocupação com:

* Separação de responsabilidades;
* Organização do código;
* Validação dos dados;
* Tratamento de erros;
* Integridade dos dados;
* Relacionamentos entre entidades;
* Uso adequado dos métodos HTTP;
* Uso adequado dos códigos de status HTTP;
* Persistência dos dados;
* Manutenibilidade.

---

# Banco de dados

Os dados deverão ser persistidos em um banco de dados.

A estrutura deverá contemplar, no mínimo, as informações necessárias para representar:

```text
Carro
 ├── Id
 ├── Marca
 ├── Modelo
 ├── AnoFabricacao
 ├── Cor
 └── Valor

Cliente
 ├── Id
 ├── Nome
 ├── Cpf
 └── DataCriacao

Reserva
 ├── Id
 ├── ClienteId
 ├── CarroId
 └── DiaReserva
```

Os relacionamentos e as restrições necessárias para garantir a integridade dos dados deverão ser definidos pelo desenvolvedor.

---

# Entrega

O projeto deverá ser disponibilizado em um **repositório do GitHub**.

O repositório deverá conter:

* Código-fonte da aplicação;
* Arquivos necessários para criação/configuração do banco de dados;
* Instruções para executar o projeto;
* Documentação dos endpoints;
* Informações necessárias para configurar o ambiente.

O projeto deverá ser possível de executar localmente seguindo as instruções disponibilizadas no próprio repositório.

---

# Critérios de avaliação

A avaliação será baseada principalmente nos seguintes pontos:

## 1. Funcionamento

* Os endpoints obrigatórios estão funcionando?
* O cadastro, atualização e remoção estão funcionando corretamente?
* A reserva está funcionando?
* A paginação está funcionando?
* Os filtros estão funcionando?

## 2. Regras de negócio

* As regras de exclusão foram implementadas corretamente?
* A API impede reservas inválidas?
* Os relacionamentos estão sendo respeitados?
* Os dados permanecem consistentes?

## 3. Qualidade do código

* O código está organizado?
* As responsabilidades estão bem separadas?
* Os nomes utilizados são claros?
* A implementação é fácil de entender e manter?

## 4. API

* Os métodos HTTP foram utilizados corretamente?
* Os status codes são adequados?
* As respostas possuem uma estrutura consistente?
* Os erros são tratados adequadamente?

## 5. Banco de dados

* O modelo está corretamente estruturado?
* Os relacionamentos estão corretos?
* A integridade dos dados é preservada?

---

# Cenários importantes

Durante o desenvolvimento, considere principalmente os seguintes cenários:

### Cenário 1 — Cadastro

Um usuário cadastra um carro com todos os dados válidos.

**Resultado esperado:** o carro é persistido com sucesso.

### Cenário 2 — Busca

Um usuário consulta os carros utilizando apenas a marca.

**Resultado esperado:** somente os carros que correspondem ao filtro são retornados.

### Cenário 3 — Filtros combinados

Um usuário pesquisa utilizando marca, modelo, ano e cor.

**Resultado esperado:** os filtros são aplicados conjuntamente.

### Cenário 4 — Reserva

Um cliente existente reserva um carro existente.

**Resultado esperado:** uma nova reserva é criada.

### Cenário 5 — Carro reservado

Um usuário tenta excluir um carro que possui uma reserva.

**Resultado esperado:** a API impede a exclusão.

### Cenário 6 — Cliente com reserva

Um usuário tenta excluir um cliente que possui uma reserva.

**Resultado esperado:** a API impede a exclusão.

### Cenário 7 — Reserva inválida

Um usuário tenta reservar um carro utilizando um cliente inexistente.

**Resultado esperado:** a API rejeita a operação.

### Cenário 8 — Carro inexistente

Um usuário tenta reservar um carro que não existe.

**Resultado esperado:** a API rejeita a operação.

---

# Objetivo final

O objetivo não é apenas criar uma API que "funcione".

Queremos avaliar a capacidade de:

1. Interpretar requisitos;
2. Modelar um domínio;
3. Criar uma API REST;
4. Trabalhar com banco de dados;
5. Implementar regras de negócio;
6. Tratar situações de erro;
7. Organizar uma aplicação;
8. Tomar decisões técnicas.

**Não existe uma única implementação correta para este desafio.**

A solução deverá demonstrar as decisões técnicas tomadas pelo desenvolvedor e sua capacidade de construir uma aplicação funcional, consistente e sustentável.

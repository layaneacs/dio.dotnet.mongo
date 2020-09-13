# Projeto de uma API .NET Integrada ao MongoDB

#### Porque usar NoSQL ?

- Perfomace
- Escalabilidade
- Flexibilidade
- Agilidade de desenvolvimento

#### As quatro classes de NoSQL

* Chave/valor (Key-Value)     - Ex.: Redis
* Colunas (Column Family)     - Ex.: Cassandra
* Documento (Document model)  - Ex.: MongoDB
* Grafos (Graph)              - Ex.: Neo4j

### Terminologia

| DB Relacional | MongoDB |
:---:|:---:
| Base de Dados | Base de Dados |
| Tabela | Coleção |
| Registro | Documento |
| Coluna | Atributo |

### Modelagens

* #### Embedded sub-document (contact e access)

```json
{
  _id: <ObjectId1>,
  username: "123xyz",
  contact : {
      phone: "21-99999-0000",
      email: "xyz@example.com"
    },
  access: {
      level: 5,
      group: "dev",
    }
}  
```

* #### Link/Referência (contact e access)

#####  user document
```json
{
    _id: <ObjectId1>,
    username: "123xyz"
}  
```

##### contact document
```json
{
    _id: <ObjectId2>,
    user_id: <ObjectId1>,
    phone: "21-99999-0000",
    email: "xyz@example.com"
}
```

##### access document
```json
{
    _id: <ObjectId3>,
    user_id: <ObjectId1>,
    level: 5,
    group: "dev"
}  
```
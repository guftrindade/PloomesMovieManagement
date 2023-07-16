# <img align="center" height="50" src="https://github.com/guftrindade/PloomesMovieManagement/assets/67704261/6f0759a1-91f7-4298-935e-57575afe3055" /> Ploomes Movie Management

Projeto de teste para um processo seletivo ao cargo de desenvolvedor na Empresa Ploomes. Trata-se de uma API de gerenciamento de filmes, tendo funcionalidades de inserção e listagem de dados conforme solicitado.

## Sobre o Projeto
Dentro dos inúmeros padrões de projeto existentes, foi adotado o **Padrão Repositório** pois permite maior oganização em relação do que foi proposto e permite a separação entre a  lógica de acesso a dados do restante da aplicação. Ele fornece uma abstração entre a camada de acesso a dados e as outras partes do sistema, permitindo que as operações de leitura e gravação de dados sejam realizadas de forma independente da implementação específica do armazenamento de dados.

#### Benefícios do padrão Repository:

 - Separação de Responsabilidades
 - Abstração do Armazenamento de Dados
 - Testabilidade
 - Reutilização de Código
 - Segregação de Operações de Leitura e Gravação

<hr>

## Execução da aplicação via Docker

A execução pelo Docker, mais especificamente pelo [Docker Compose](https://docs.docker.com/compose/), é muito mais simples e rápido , pois não é necessário ter toda a stack necessária para executar a aplicação, mas somente o Docker.

- Obviamente, instalar o Docker habilitando o WSL2 e virtualização, principalmente se estiver no SO Windows;
- Abra o terminal no diretório */deploy* e execute o seguinte comando:

    ```
    docker-compose -f nerdstore-producao.yml up --build
    ```

    **OBS.:** *--build* é uma flag opcional que força a criação de todas as imagens docker.

- Para remover todos os containers docker gerados a partir das imagens docker basta usar o seguinte comando:

    ```
    docker-compose -f nerdstore-producao.yml down
    ```

**OBS.:** pode ocorrer de ao rodar pelo Docker através do docker-compose as API's subam primeiro do que o broker de mensagens (Event Bus). Isso acaba levando nas API's não se conectarem broker de mensagens e ocasionar inconsistências na aplicação. Caso isto ocorra basta restartar as instâncias dos containers de todas as API's manualmente pelo Docker e voltará a funcionar corretamente.

<hr>
## Arquitetura
![image](https://github.com/guftrindade/PloomesMovieManagement/assets/67704261/d1024533-0d5a-4118-a898-2c278781a39d)
---
Foi aplicado o redis com o objetivo de otimizar as consultas. sendo assim, quando faz uma requsição ao banco de dados, primeiramente é verificado o cache e caso não tenha informações ou o tempo já tenha expirado, é então solicitado ao banco de dados e configurado posteriormente no redis para próximas consultas.

![image](https://github.com/guftrindade/PloomesMovieManagement/assets/67704261/cbfc5cdb-b7c8-4152-b68f-684acb7b119a)
---

### Swagger Documentation
![image](https://github.com/guftrindade/PloomesMovieManagement/assets/67704261/69541d66-9586-4ce5-8eaa-c3792208c805)
---
![image](https://github.com/guftrindade/PloomesMovieManagement/assets/67704261/0a6e989b-37eb-4a28-9655-a0bf5410f5f7)

### Tecnologias Utilizadas e Informações Adicionais
 - .Net 7
 - SQL Server
 - Entity Framework Core
 - Redis
 - TDD
 - Classes refatoradas (Program.cs)
 - Swagger Documentation

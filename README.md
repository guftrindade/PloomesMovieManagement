# <img align="center" height="50" src="https://github.com/guftrindade/PloomesMovieManagement/assets/67704261/6f0759a1-91f7-4298-935e-57575afe3055" /> Ploomes Movie Management

Projeto de teste para um processo seletivo ao cargo de desenvolvedor na Empresa [Ploomes](https://www.ploomes.com/). Trata-se de uma API de gerenciamento de filmes, tendo funcionalidades de inserção, listagem de dados conforme solicitado pelo escopo do processo. 

<hr>

### Execução da aplicação via Docker
- Abra o terminal de comando no diretório do projeto e execute o seguinte comando utilizando o [Docker Compose](https://docs.docker.com/compose/)

    ```
    docker-compose up
    ```

- O Projeto irá rodar na porta 5102, conforme o seguinte link

    ```
    http://localhost:5102/swagger/index.html
    ```

- Para remover os container basta inserir o seguinte comando

    ```
    docker-compose down
    ```
<hr>

## Arquitetura
![image](https://github.com/guftrindade/PloomesMovieManagement/assets/67704261/d1024533-0d5a-4118-a898-2c278781a39d)
---
![image](https://github.com/guftrindade/PloomesMovieManagement/assets/67704261/de8b1865-6b67-469a-974f-110a0559d7f6)
---
Foi aplicado o redis com o objetivo de otimizar as consultas. sendo assim, quando faz uma requsição ao banco de dados pelo Id, primeiramente é verificado o cache e caso não tenha informações ou o tempo já tenha expirado, 
é então solicitado ao banco de dados e configurado posteriormente no redis para próximas consultas.


### Tecnologias e Informações Adicionais usadas no desenvolvimento do projeto
 - .Net 7
 - SQL Server
 - Entity Framework Core
 - Redis
 - TDD
 - Organização de classe Program.cs
 - Swagger Documentation
 - Logs de exceções
 - Responses customizados
 - Paginação de API
 - Conteinerização

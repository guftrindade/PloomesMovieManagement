# <img align="center" height="50" src="https://github.com/guftrindade/PloomesMovieManagement/assets/67704261/6f0759a1-91f7-4298-935e-57575afe3055" /> Ploomes Movie Management

Projeto de teste para um processo seletivo ao cargo de desenvolvedor na Empresa [Ploomes](https://www.ploomes.com/). Trata-se de uma API de gerenciamento de filmes, tendo funcionalidades de inserção, listagem de dados conforme solicitado pelo escopo do processo. 

<hr>

### Execução da aplicação via Docker
- Após clonar o projeto para sua máquina local, bra o terminal de comando no diretório do raiz projeto *PloomesMovieManagement* e execute o seguinte comando utilizando o [Docker Compose](https://docs.docker.com/compose/) - *Lembre-se de estar com o docker executando*

    ```
    docker-compose up
    ```

- O Projeto irá rodar na porta 5102, basta acessar o seguinte endereço

    ```
    http://localhost:5102/swagger/index.html
    ```

- Para remover os container basta inserir o seguinte comando

    ```
    docker-compose down
    ```
<hr>

<p align="center">
    <img  src="https://github.com/guftrindade/PloomesMovieManagement/assets/67704261/de8b1865-6b67-469a-974f-110a0559d7f6">
    &nbsp;
    <img  src="https://github.com/guftrindade/PloomesMovieManagement/assets/67704261/b9309cf6-76a9-4b27-b30f-73f119088390">

</p>

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

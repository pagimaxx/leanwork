# leanwork
Repositório do teste da LeanWork

## Explicando as decisões das soluções aplicadas no teste

**Parte 1**

Para a do teste, foi escolhido uma aplicação Windows Form, pois necessitava executar tarefas que necessitavam de algum tipo de ativação, e para isso optei pela utilização de um botão, e o Linq foi utilizado o melhor possível para a solução.

**Parte 2**

Para a parte dois escolhi a utilização do Angular em sua versão 8, foi desenvolvido em uma arquitetura separando as suas respectivas responsabilidades, como componentes, pages e services, para o layout da página escolhi um template chamado CoreUI e adaptei para que layout para a utilização com o Angular, na camada service foi implantada toda a conexão com os serviços do Github, no pages foi inserida todas as telas disponíveis para a visualização criando 2 telas para a exibição uma para listar e outra para detalhar.

**Parte 3**

O conhecimento em API Restful foi o tema desta parte, para a solução das atividades, eu escolhi utilizar a tecnologia .NET Core utilizando um design DDD e Repository Pattern com o Dapper para a conexão com o banco de dados SQLServer, a arquitetura foi distribuída em camadas (Domain, CrossCutting, IoC, Repository, AppService, Api), para a apresentação dos endpoints apliquei o Swagger para uma melhor documentação API, a injeção de dependência também foi implantada com o próprio IndependecyInjection nativo do .Net Core, e o UnitOfWork comitando os dados no banco e centralizando toda a “conversa” com banco de dados.

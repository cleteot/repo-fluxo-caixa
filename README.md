# Fluxo de Caixa
Teste para criação de serviços de fluxo de caixa

## Solicitação
Um comerciante necessita de um sistema para gerenciar seu fluxo de caixa diário, registrando todas as 
transações, tanto entradas (créditos) quanto saídas (débitos). Além disso, é essencial que o sistema possa 
fornecer um relatório que apresente o saldo consolidado no final de cada dia.

### Requisitos de negócio
▪  Desenvolvimento de um serviço que permita o registro e gerenciamento de lançamentos financeiros, 
abrangendo tanto débitos quanto créditos;
▪ Criação de um serviço que gere relatórios de consolidado diário, apresentando de forma clara e 
organizada o saldo financeiro ao final de cada dia.


## Arquitetura da Solução
O modelo escolhido para definição do desenho do arquitetura foi o c4Model (https://c4model.com/), pois este modelo nos permite ir detalhando o sistema a medida que vamos conhecendo melhor o projeto.

### Diagrama de contexto do sistema (Nível 1)
<img src="Documentacao\01.Diagrama de contexto do sistema.png" alt="Diagrama de contexto" with="400px" height="500px">

### Diagrama de container (Nível 2)
<img src="Documentacao\02.Conteiner.png" alt="Diagrama de container" with="400px" height="500px">

### Diagrama de componente API Application (Nível 3)
<img src="Documentacao\03.ComponenteAPIApplication.png" alt="Componente API Apllication" with="400px" height="500px">

### Diagrama de componente Mensageria (Nível 3)
<img src="Documentacao\04.ComponenteMensageria.png" alt="Componente Mensageria" with="400px" height="500px">

## Diagrama de Banco de Dados
<img src="Documentacao\Diagrama ER de banco de dados Fluxo de Caixa.jpeg" alt="Diagrama de Banco de Dados" with="400px" height="500px">

### Definições Arquiteturais, Padrões de Projeto e Frameworks
1) Microsserviços
    Este projeto será desenvolvido em microsserviços, pois este modelo nos orienta a criarmos serviços independentes que por sua vez tem as seguintes vantagens:
. Descentralização: Cada microsserviço opera como uma unidade independente e autônoma, geralmente com seu próprio banco de dados.
. Comunicação: Os microsserviços se comunicam entre si por meio de interfaces bem definidas, como APIs.
. Escalabilidade Independente: Cada serviço pode ser dimensionado separadamente, permitindo melhor escalabilidade.
. Resiliência: Se um serviço falha, isso não afeta diretamente outros serviços.
. Implantação Independente: Cada serviço pode ser construído, testado e implantado independentemente dos outros.
. Como desvantagem, gerenciar varias partes de sistema e garantir sua consistência.
3) Padrões de Projeto
    3.1) DDD (Domain-Driven Design)
      Foca no entendimento profundo do domínio antes da criação de soluções técnicas, o que nos permite primeiro olhar para o negócio e depois como será resolvido técnicamente
    3.2) Repository
       Fornece uma interface para acessar dados, proporciona um ponto centralizado de leitura e gravação de dados, mantém a lógica de negócios desacopladas.     
4) Frameworks
     4.1) EntityFrameWork (ORM)
       Permite lidarmos diretamente com o objetos, tem suporte a vários provedores de banco de dados. 
    4.2) AutoMapper
       Como cada camada da aplicação terá seu objeto de entidade, é comum fazermos a correspondência entre este objetos e o AutoMapper agiliza esta tarefa.







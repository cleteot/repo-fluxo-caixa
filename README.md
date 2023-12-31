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
**1) Microsserviços**
    Este projeto será desenvolvido em microsserviços, pois este modelo nos orienta a criarmos serviços independentes que por sua vez tem as seguintes vantagens:
- **Descentralização**: Cada microsserviço opera como uma unidade independente e autônoma, geralmente com seu próprio banco de dados.
- **Comunicação**: Os microsserviços se comunicam entre si por meio de interfaces bem definidas, como APIs.
- **Escalabilidade Independente**: Cada serviço pode ser dimensionado separadamente, permitindo melhor escalabilidade.
- **Resiliência**: Se um serviço falha, isso não afeta diretamente outros serviços.
- **Implantação Independente**: Cada serviço pode ser construído, testado e implantado independentemente dos outros.
- Como desvantagem, gerenciar varias partes de sistema e garantir sua consistência.
  
**2) Padrões de Projeto**
  - DDD (Domain-Driven Design)
      - Foca no entendimento profundo do domínio antes da criação de soluções técnicas, o que nos permite primeiro olhar para o negócio e depois como será resolvido técnicamente
  - Repository
      - Fornece uma interface para acessar dados, proporciona um ponto centralizado de leitura e gravação de dados, mantém a lógica de negócios desacopladas.
             
**3) Frameworks**
  - EntityFrameWork (ORM)
      - Permite lidarmos diretamente com o objetos, tem suporte a vários provedores de banco de dados.
  - AutoMapper
      - Como cada camada da aplicação terá seu objeto de entidade, é comum fazermos a correspondência entre este objetos e o AutoMapper agiliza esta tarefa.
  - xUnit
      - Framework para escrever testes unitários, e é possível criar extensões personalizadas para atender requisitos específicos  

## Ferramentas
- Visual Studio 2022 para desenvolvimento
- Linguagem de programação .Net Core 6 (Fornece suporte a longo prazo)
- Gerenciador de Banco de Dados MS SQL SERVER, hospedado no AZURE
- Gerenciador de Filas de Mensagens RabbitMQ hospedado na AWS
- Docker para subir os Conteiners de cada serviço e do consumidor de mensagens
- Draw.io para criação do Diagrama de Arquitetura
- Lucidchart para criação do Digrama de Banco de Dados

## Fluxo Principal do Sistema
<img src="Documentacao\Fluxo Principal Incluir Transacao.png" alt="Fluxo Incluir Transação">

## Para testar o projeto
1. Após clonar o projeto

2. Padrão inciciar multiplos projetos no visual studio
- <img src="Documentacao\TestarVisualStudio.png" alt="Multiplos Projetos">
- <img src="Documentacao\VisualStudio2.JPG" alt="Iniciar Debug">

3. No Visual Studio via projeto docker-compose
- <img src="Documentacao\VisualStudioDockerCompose.JPG" alt="Docker-Compose via projeto do Visual Studio">

4. Por lina de comando do docker
- Via DOS, PowerShell ou Terminal Windows
- Navegar até a pasta da solução
- digitar: **docker-compose up -d**

## Link dos serviços que serão carregados
- **Saldo Service:** http://localhost:59750/
- **Transacao Service:** https://localhost:44373/
- **Relatorio Service:** https://localhost:44337/










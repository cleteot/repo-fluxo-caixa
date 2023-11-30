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
<img src="Documentacao\01.Diagrama de contexto do sistema.png" alt="Diagrama de contexto">

### Diagrama de container (Nível 2)
<img src="Documentacao\02.Conteiner.png" alt="Diagrama de container">

### Diagrama de componente API Application (Nível 3)
<img src="Documentacao\03.ComponenteAPIApplication.png" alt="Componente API Apllication">

### Diagrama de componente API Application (Nível 3)
<img src="Documentacao\04.ComponenteMensageria.png" alt="Componente Mensageria">


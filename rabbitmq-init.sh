#!/bin/sh

# Inicializar RabbitMQ
rabbitmq-plugins enable rabbitmq_management

# Aguardar até que o RabbitMQ esteja pronto para aceitar comandos
until rabbitmqctl node_health_check; do
  sleep 5
done

# Definir um exchange
rabbitmqctl exchange_declare -v / -p / meu_exchange2 tipo_fanout

# Definir uma fila
rabbitmqctl queue_declare -v / -p / minha_fila2

# Vincular a fila ao exchange
rabbitmqctl queue_bind -v / -p / minha_fila2 meu_exchange2

# Reiniciar o RabbitMQ para aplicar as configurações
rabbitmqctl stop_app
rabbitmqctl start_app

# Sair do script
exit 0

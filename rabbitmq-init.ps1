# PowerShell script para inicializar RabbitMQ

# Esperar at� que o RabbitMQ esteja pronto para aceitar conex�es
do {
    Start-Sleep -Seconds 5
} until (Test-NetConnection -ComputerName localhost -Port 5672)

# Configura��o do RabbitMQ
Invoke-RestMethod -Uri "http://localhost:15672/api/exchanges/%2f/fluxo_exchange1" -Method PUT -Headers @{"Content-Type"="application/json"} -Credential (Get-Credential)
Invoke-RestMethod -Uri "http://localhost:15672/api/queues/%2f/fluxo_fila1" -Method PUT -Headers @{"Content-Type"="application/json"} -Credential (Get-Credential)
Invoke-RestMethod -Uri "http://localhost:15672/api/bindings/%2f/e/fluxo_exchange/q/fluxo_fila1" -Method POST -Headers @{"Content-Type"="application/json"} -Credential (Get-Credential)

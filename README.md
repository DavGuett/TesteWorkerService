# Worker Service

Projeto criado para testar funcionalidade de logs e a criação de um serviço windows que roda no background, monitorando o status do site Proa.Tec.Br e escrevendo as informações em um arquivo de log.

## Instalação

Para instalar o programa, abra-o no Visual Studio e publique no local de sua escolha, após isso você deve abrir um terminal do PowerShell (ou o terminal novo do Windows 11) como administrador e rodar o seguinte comando:

```
sc.exe create {nome do serviço} binpath= {diretório instalado/nome.exe} start= auto
```

O comando adiciona a aplicação como serviço do Windows e a configura para iniciar automaticamente junto com o computador.
Para remover o serviço, certifique-se de que ele esteja parado e rode o comando:

```
sc.exe delete {nome do serviço}
```

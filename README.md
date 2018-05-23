# R.O.B.O.

[![Build Status](https://travis-ci.org/alisonjonck/robo.svg?branch=dev)](https://travis-ci.org/alisonjonck/robo)

## Download última versão .NET Core SDK

* [.NET Core 2.0 SDK](release-notes/download-archives/2.0.3.md)

### Clone o projeto
```
git clone https://github.com/alisonjonck/robo.git
```

### Execute os testes
```
cd robo/Robo
dotnet test
```

### Faça build e rode a aplicação
```
dotnet build
dotnet WebApi/WebApi/bin/Debug/netcoreapp2.0/WebApi.dll
```
### Retornar R.O.B.O.
```
GET | http://localhost:5000/api/robo
```
### Atualizar estados do R.O.B.O.
```
PUT | http://localhost:5000/api/robo
```

### Swagger:

```http://localhost:5000/swagger/```

### R.O.B.O.
```
# Robo:
{
    Cabeca: {...},
    BracoDireito: {...},
    BracoEsquerdo: {...}
}
# Cabeça:
{
    Rotacao,
    Inclinacao
}
# Braço Direito/Esquerdo:
{
    Cotovelo,
    Pulso
}
```
# Estados Cabeça R.O.B.O.

### Rotação
* Rotação -90º
* Rotação -45º
* Em Repouso
* Rotação 45º
* Rotação 90º

### Inclinação
* Para Cima
* Em Repouso
* Para Baixo

# Estados Braço Direito/Esquerdo R.O.B.O.

### Cotovelo
* Em Repouso
* Levemente Contraído
* Contraído
* Fortemente Contraído

### Pulso
* Rotação para -90º
* Rotação para -45º
* Em Repouso
* Rotação para 45º
* Rotação para 90º
* Rotação para 135º
* Rotação para 180º


# Restrições do R.O.B.O.

* O estado inicial dos movimentos é Em Repouso
* Só poderá movimentar o Pulso caso o Cotovelo esteja Fortemente Contraído
* Só poderá Rotacionar a Cabeça caso sua Inclinação da Cabeça não esteja em estado Para Baixo
* Ao realizar a progressão de estados, é necessário que sempre siga a ordem crescente ou decrescente, por exemplo, a partir do estado 4, pode-se ir para os estados 3 ou 5
* Atenção aos limites! Se tentar enviar um estado inválido você irá corromper o sistema do R.O.B.O.
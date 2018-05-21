# R.O.B.O.

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



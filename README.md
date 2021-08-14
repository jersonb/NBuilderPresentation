# NBuilderPresentation

> Este repositório tem a intenção de promover a biblioteca [NBuilder](https://github.com/nbuilder/nbuilder) através de exemplos simples para iniciantes ou um tutorial de como gerar réplicas de objetos de maneira mais eficiente.

## Instância simples

O **NBuilder** é capaz de instanciar objetos e atribuir valores as propriedades de tipos internos de maneira extremamente simples. Por exemplo o objeto ```Invoice``` a baixo foi gerado com o código:

```csharp
    Builder<Invoice>.CreateNew().Build()
```

```json
    {
        "externalId": "00000000-0000-0000-0000-000000000001",
        "id": 1,
        "description": "Description1",
        "isActive": false,
        "amount": 1,
        "date": "2021-08-14T00:00:00",
        "invoiceType": 1,
        "obsevations": null,
        "items": null,
        "user": null
    }
```

**Observe que:**

- A propriedade ```externalId``` é um ```Guid``` e a pesar de ser semelhante ao valor *default*, este é um valor válido para este tipo.

- As propriedades numéricas, ```id``` e```amount```, não estão com zero.

- A propriedade ```description``` é do tipo ```string``` e recebeu como valor o nome concatenado com 1.

- ```isActive``` claramente é um *booleano* onde o valor ```false``` é um valor  

- Os tipos que são ```DateTime``` como o ```date``` recebem a data atual onde o *default* seria ```01/01/0001 00:00:00```.

- Já o ```invoiceType``` é do tipo ```enum InvoiceType``` seu valor *default* seria zero, desta forma seria inválido pois neste caso para este tipo o valor 1 foi atribuído ao primeiro caso.

- Como citado anteriormente, as propriedades complexas recebem ```null``` neste caso ```obsevations``` é um ```List<string>```, ```items``` é um ```List<Item>``` e ```user``` é do tipo ```User```.

## Gerando uma lista de objetos simples

Da mesma forma que criamos um único objeto, também podemos criar uma lista. Por exemplo, uma lista de ```Item``` será gerada com o seguinte código:

```csharp
    Builder<Item>.CreateListOfSize(3).Build()
```

```json
    [
        {
            "externalId": "00000000-0000-0000-0000-000000000001",
            "id": 1,
            "name": "Name1",
            "isActive": false,
            "value": 1
        },

        {
            "externalId": "00000000-0000-0000-0000-000000000002",
            "id": 2,
            "name": "Name2",
            "isActive": true,
            "value": 2
        },

        {
            "externalId": "00000000-0000-0000-0000-000000000003",
            "id": 3,
            "name": "Name3",
            "isActive": false,
            "value": 3
        }
    ]
```

**Observe que:**

- Os valores recebem um incremento a cada item da lista, desta forma todos os objetos são diferentes entre si.

- Já propriedade ```isActive``` que é *booleana* alterna entre ```false``` e ```true``` a cada objeto.

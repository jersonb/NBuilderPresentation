# NBuilderPresentation

> Este repositório tem a intenção de promover a biblioteca [NBuilder](https://github.com/nbuilder/nbuilder) através de exemplos simples para iniciantes ou um tutorial de como gerar réplicas de objetos de maneira mais eficiente.

## Instância simples

O **NBuilder** é capaz de instanciar objetos e atribuir valores as propriedades de tipos internos de maneira extremamente simples. Por exemplo o objeto a baixo foi gerado com o código:

```csharp
    Builder<T>.CreateNew().Build()
```

```json
    {
        "ExternalId": "00000000-0000-0000-0000-000000000001",
        "Id": 1,
        "Description": "Description1",
        "IsActive": false,
        "Amount": 1,
        "Date": "2021-08-14T00:00:00",
        "InvoiceType": 1,
        "Obsevations": null,
        "Items": null,
        "User": null
    }
```

### Observe que

- A propriedade ```ExternalId``` é um ```Guid``` e a pesar de ser semelhante ao valor *default*, este é um valalor válido para este tipo.

- As propriedades numéricas, ```Id``` e```Amount```, não estão com zero.

- A propriedade ```Description``` é do tipo ```string``` e recebeu como valor o nome concatenado com 1.

- Já o ```InvoiceType``` é do tipo ```enum``` seu valor *default* seria zero, desta forma seria inválido pois neste caso para este tipo o valor 1 foi atribuído ao primeiro caso.

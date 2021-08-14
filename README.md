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

## Configurando valores

Como foi visto no primeiro exemplo os valores de tipos criados ou complexos não são atribuídos. Porém podemos configura-los informando para o **NBuilder** qual são os valor que devem ser atribuídos a essas propriedades. Faremos isso utilizando o método de extensão ```With```. Vale ressaltar que para configurar uma lista é necessário dizer quais os elementos receberam aquela configuração, neste caso será utilizado método ```All``` atribuindo assim o mesmo valor para todos os elementos.

```csharp
    IList<Item> items = Builder<Item>
                        .CreateListOfSize(2)
                        .All()
                        .With(item => item.IsActive, true)
                        .Build();

    User user = Builder<User>
                .CreateNew()
                .With(user => user.IsActive, true)
                .Build();

    Invoice invoice = Builder<Invoice>
                      .CreateNew()
                      .With(invoice => invoice.Items, items)
                      .With(invoice => invoice.User, user)
                      .With(invoice => invoice.IsActive, true)
                      .Build();
```

Com o código acima obteremos o seguinte objeto:

```json
    {
        "externalId": "00000000-0000-0000-0000-000000000001",
        "id": 1,
        "description": "Description1",
        "isActive": true,
        "amount": 1,
        "date": "2021-08-14T00:00:00",
        "invoiceType": 1,
        "items": [
            {
                "externalId": "00000000-0000-0000-0000-000000000001",
                "id": 1,
                "name": "Name1",
                "isActive": true,
                "value": 1
            },
            {
                "externalId": "00000000-0000-0000-0000-000000000002",
                "id": 2,
                "name": "Name2",
                "isActive": true,
                "value": 2
            }
        ],
        "user": {
            "externalId": "00000000-0000-0000-0000-000000000001",
            "id": 1,
            "name": "Name1",
            "isActive": true
        },
        "obsevations": null
    }
```

**Observe que:**

- Todas as propriedades ```isActive``` de todos os objetos envolvidos estão ```true``` como configurado.

## Utilizando valores randômicos

Apesar de termos o objeto ```Invoice``` praticamente populado e sendo gerado automaticamente, ainda falta resolver a propriedade ```obsevations``` que é um ```List<string>```. Para isto utilizaremos a classe interna do **NBuider** a ```RandomGenerator``` e assim conseguir obter um texto randômico. Em seguida "fatiamos" o texto por espaço e transformamos em uma lista de strings. Faremos isso com o seguinte código:

```csharp
    var ramdom = new RandomGenerator();
    
    int MIN_LEGTH = 2;
    int MAX_LEGTH = 100;
    int sizePhase = ramdom.Next(MIN_LEGTH, MAX_LEGTH);
    string phrase = ramdom.Phrase(sizePhase);
    string[] wordsArray = phrase.Split(" ");
    List<string> wordsList = wordsArray.ToList();

    //ou simplesmente

    var observations = ramdom.Phrase(ramdom.Next(2, 100)).Split(" ").ToList();
```

E ao adicionarmos a configuração ```With(invoice => invoice.Obsevations, observations)``` finalmente termos o objeto ```Invoice``` completo:

```json
    {
        "externalId": "00000000-0000-0000-0000-000000000001",
        "id": 1,
        "description": "Description1",
        "isActive": true,
        "amount": 1,
        "date": "2021-08-14T00:00:00",
        "invoiceType": 1,
        "items": [
            {
                "externalId": "00000000-0000-0000-0000-000000000001",
                "id": 1,
                "name": "Name1",
                "isActive": true,
                "value": 1
            },
            {
                "externalId": "00000000-0000-0000-0000-000000000002",
                "id": 2,
                "name": "Name2",
                "isActive": true,
                "value": 2
            }
        ],
        "user": {
            "externalId": "00000000-0000-0000-0000-000000000001",
            "id": 1,
            "name": "Name1",
            "isActive": true
        },
       "obsevations": [
            "adipisicing",
            "et",
            "adipisicing",
            "ut"
        ]
    }
```

**Observe que:**

- Desta forma a quantidade e conteúdo de ```obsevations``` irá sempre ser diferente, isso pode ser bom para abranger ainda mais seus testes, ou ruim caso queria fazer um teste de unidade totalmente focado nesta propriedade.

## Obtendo um objeto totalmente randômico

Em um senário real, ou ao menos em um caso de teste real este objeto poderia ter algum comportamento a mais, como por exemplo, a propriedade ```amount``` representar a soma dos valores dos itens, ou o nome do ```user``` relacionado ter algum tipo de regra com relação ao tamanho. Enfim um senário que seria mais interessante onde esses valores fosse randômicos.

```csharp
    var ramdom = new RandomGenerator();

    IList<Item> items = Builder<Item>
                          .CreateListOfSize(2)
                          .All()
                          .Do(item => 
                          {
                              item.Name = ramdom.Phrase(10);
                              item.Value = ramdom.Next(1m, 100m);
                          })
                          .With(item => item.IsActive, true)
                          .Build();

    User user = Builder<User>
                  .CreateNew()
                  .With(user => user.IsActive, true)
                  .With(user => user.Name, ramdom.Phrase(50))
                  .Build();

    Invoice invoice = Builder<Invoice>
                        .CreateNew()
                        .With(invoice => invoice.Items, items)
                        .With(invoice => invoice.User, user)
                        .With(invoice => invoice.Obsevations, ramdom.Phrase(ramdom.Next(2, 30)).Split(" ").ToList())
                        .With(invoice => invoice.Amount = invoice.Items.Sum(item => item.Value))
                        .With(invoice => invoice.Date, ramdom.Next(DateTime.Now, DateTime.Now.AddDays(-10)))
                        .With(invoice => invoice.InvoiceType, ramdom.Enumeration<InvoiceType>())
                        .With(invoice => invoice.Description = invoice.InvoiceType.ToString())
                        .With(invoice => invoice.IsActive, true)
                        .Build();
```

```json
    {
        "externalId": "00000000-0000-0000-0000-000000000001",
        "id": 1,
        "description": "CREDIT_INVOICE",
        "isActive": true,
        "amount": 162.3875,
        "date": "2021-08-06T19:48:47.521728",
        "invoiceType": 12,
        "obsevations": [
            "labore",
            "lorem",
            "dolore"
        ],
        "items": [
            {
                "externalId": "00000000-0000-0000-0000-000000000001",
                "id": 1,
                "name": "et dolor",
                "isActive": true,
                "value": 72.263
            },
            {
                "externalId": "00000000-0000-0000-0000-000000000002",
                "id": 2,
                "name": "labore",
                "isActive": true,
                "value": 90.1245
            }
        ],
        "user": {
            "externalId": "00000000-0000-0000-0000-000000000001",
            "id": 1,
            "name": "sed tempor dolore incididunt dolor incididunt do",
            "isActive": true
        }
    }
```

**Observe que:**

- Ao criar a lista de itens foi utilizado o método ```Do``` com uma ```Action``` para definir algumas propriedades, desta forma a cada item obteremos valores diferentes, caso fosse utilizado o ```With``` obteríamos os valores repetidos para todos os itens assim como acontece em ```isActive``` .

- No ```With``` pode-se atribuir valores de duas formas. :

  1. Com uma ```Func``` no primeiro parâmetro para determinar a propriedade e um segundo parâmetro com o valor.  

  2. Apenas com uma ```Func``` que recebe diretamente atribuição.

Para referenciar a uma propriedade interna existente apenas a segunda maneira funciona, como por exemplo na atribuição de ```Amount``` em invoice.

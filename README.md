# Reconhecimento-de-Terreno

Você trabalha no Exército brasileiro e será o principal responsável pelo desenvolvimento de um software de reconhecimento de terreno. Esse software irá utilizar um novo dispositivo de radar adquirido. O dispositivo funciona de acordo com as seguintes especificações, descritas em seu manual:

1 – O dispositivo faz a leitura de uma área quadrada limitada de cada vez. Essa área é representada por matrizes 50x50, onde cada item representa 1 m² da área lida. O valor de cada item da matriz dependerá do tipo de leitura feita.

2 – Pode ser obtida uma leitura para identificar possíveis obstáculos à passagem na área lida, utilizando o método ObterLeituraDeObstaculos. Cada elemento dessa matriz pode assumir o valor “0”, caso não corresponda a um obstáculo, ou “1”, caso contrário.

3 – Pode ser obtida uma leitura da probabilidade de existirem minas terrestres em cada m² da região, utilizando o método ObterLeituraDeMinasTerrestres. Nesse caso, cada elemento da matriz possuirá um valor de 0 a 100, correspondente à probabilidade de existirem minas naquele m².

4 – Pode ser obtida uma leitura do tipo de terreno. Nesse caso, cada elemento da matriz possuirá o valor “0”, caso corresponda a terra firme, ou um valor numérico acima de 0 caso corresponda a água, sendo que o valor representa a profundidade do terreno coberto por água em metros.

5 – Os métodos de obtenção de leitura já vem prontos na biblioteca de funções do dispositivo. 

	Em reunião com um especialista nessa área, foram levantadas as seguintes regras:

1 – É possível atravessar a pé um m² do terreno coberto por água se ela tiver no máximo 1 metro de profundidade. Não é possível ultrapassar a pé um m² do terreno que contém obstáculos.

2 – Um terreno pode ser classificado em 4 níveis de segurança:

Nível 1 –Área segura – Não existe em nenhum local no terreno probabilidade maior que 50% de chance de ter uma mina terrestre.

Nível 2 – Área de atenção – Área não segura onde até 10% da área do terreno tem uma probabilidade maior que 50% de ter minas terrestres.

Nível 3 – Área perigosa – 10 a 50% da área do terreno tem uma probabilidade maior que 50% de ter minas terrestres.

Nível 4 – Área não recomendada – Mais de 50% da área do terreno tem uma probabilidade maior que 50% de ter minas terrestres.

Com base nessas regras, pede-se:
6 – Desenvolva um algoritmo que faça a leitura de um terreno e informe o percentual de sua área coberta por água ou obstáculos.

7 – Desenvolva um algoritmo que faça a leitura de um terreno e informe a profundidade média de toda sua área coberta por água.

8 – Desenvolva um algoritmo que determine se um terreno pode ser ultrapassado a pé em linha reta. Caso a única linha reta onde seja possível ultrapassar o terreno possua algum m² com uma probabilidade maior que 10% de conter minas, o usuário deve ser avisado.

9 - Desenvolva um algoritmo que faça a leitura de um terreno e informe seu nível de segurança.

10 – Desenvolva um algoritmo que faça a leitura de um terreno e determine se no terreno existe uma ilhota estrategicamente útil. Uma ilhota é um espaço de 1m² de terra cercado de água por todos os lados. Só é estrategicamente útil se não possuir um obstáculo e possuir probabilidade 0 de conter minas.

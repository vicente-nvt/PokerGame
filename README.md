# PokerGame

No jogo de poker, uma mão consiste em cinco cartas que podem ser comparadas, da mais baixa para a mais alta, da seguinte maneira:

* **Carta alta** - a carta de maior valor;
* **Um par** - duas cartas do mesmo valor;
* **Dois pares** - dois pares diferentes;
* **Trinca** - três cartas do mesmo valor e duas de valores diferentes;
* **Straight (sequência)** - todas as cartas com valores consecutivos;
* **Flush** - todas as cartas do mesmo naipe;
* **Full house** - uma trinca e um par;
* **Quadra** - quatro cartas do mesmo valor;
* **Straight flush** - todas as cartas são consecutivas e do mesmo naipe;
* **Royal flush** - a sequência 10, Valete, Dama, Rei, Ás do mesmo naipe;

### **Observações:**

As cartas são, em ordem crescente de valor: 2, 3, 4, 5, 6, 7, 8, 9, 10 (T), Valete (J), Dama (Q), Rei (K) e Ás (A).

Os naipes são: Ouros (D - Diamonds), Copa (H - Hearts), Espadas (S - Spades) e Paus (C - Clubs).

Se dois jogadores possuem a mesma mão, vence quem tiver a mão formada pelas cartas de maior valor.

Desenvolva um programa que, de acordo com as mãos de dois jogadores, informe qual deles é o vencedor.

### Alguns exemplos de mãos e seus respectivos vencedores:

**Ex. 1:**

Jogador 1 - 5H 5C 6S 7S KD (Par de cinco).

Jogador 2 - 2C 3S 8S 8D TD (Par de oito).

*Vencedor*: Jogador 2.

**Ex. 2:**

Jogador 1 - 5D 8C 9S JS AC (Carta mais alta: Ás).

Jogador 2 - 2C 5C 7D 8S QH (Carta mais alta: Dama).

*Vencedor*: Jogador 1.

**Ex.3:**

Jogador 1 - 2D 9C AS AH AC (Trinca de Ás).

Jogador 2 - 3D 6D 7D TD QD (Flush com Ouro).

*Vencedor*: Jogador 2.

**Ex.4:**

Jogador 1 - 4D 6S 9H QH QC (Par de damas) - Carta mais alta: 9.

Jogador 2 - 3D 6D 7H QD QS (Par de damas) - Carta mais alta: 7

*Vencedor*: Jogador 1.

**Ex.5:**

Jogador 1 - 2H 2D 4C 4D 4S (Full house) - Com três 4.

Jogador 2 - 3C 3D 3S 9S 9D (Full house) - Com três 3.

*Vencedor*: Jogador 1.

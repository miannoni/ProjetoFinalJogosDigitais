# Lawn Mow-ter Sport
### Caracteristicas do jogo:
- A grama é cortada quando o personagem passa por cima dela, usando a ferramenta de terrain e grama do unity
- Quando o personagem corta a grama, o tanto de grama que ele corta é mostrado no UI dele e ele recebe um boost de velocidade proporcional à grama cortada.
- Tem duas IA's programadas, porem só deu tempo de usar uma. A primeira usa pathfinding simples e a segunda usa um algoritmo de IA de corrida emprestado da standard assets (o segundo foi o utilizado no projeto final) que foi configurado em ambos os mapas para seguir os checkpoints e que tem um grau de aleatoriedade pra não ser chato correr contra ele.
- Tem dois mapas implementados, um deles é uma floresta e o outro é uma ilha no meio do mar, estilo mario kart.
- Os checkpoints foram desenvolvidos de um jeito muito legal (eles foram meu nenem desse projeto). No editor do unity, se você quiser criar um mapa novo, você só precisa arrastar uma finishline (pode ser um checkpoint normal, mas o primeiro é o que vai ser a linha de chegada) pro 'mapa' (não precisa ser um terrain) e aí arrastar todos os outros checkpoints (quantos vocé quiser) e tudo já funciona; eles ficam iluminados dependendo deles estarem ativos ou não pro player, comunicam pro player quando ele passa neles e permitem ao player a contagem de voltas na pista independentemente de quantos checkpoints foram usados e sem nenhuma necessidade de mudar nenhum script.
- O jogo tem um sistema de menu's bastante funcional (aperte 'P' durante a corrida), o unico bug é que o oponente não para quando você ta no menu porque não foi implementada a flag 'pause nele'.
- A GUI durante a corrida mostra sua velocidade (funcionando), posicao (não foi feita a implementação da mecanica em si), volta (implementada mas não há condição de vitoria, pois não deu tempo de implementar), e quantidade de grama cortada (funcionando).

### Controlando o jogo:
Para controlar o menu, utilize ws ou as setas pra cima e pra baixo e enter.
Para controlar o personagem na corrida use wasd/setas e pressione 'p' pra pausar o jogo.

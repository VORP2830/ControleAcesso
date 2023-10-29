
# Controle de acesso

O Sistema de Controle de Acesso foi projetado para gerenciar de maneira eficaz e segura as permissões dos usuários em relação às funcionalidades e métodos do sistema. Esta documentação descreve o funcionamento e a implementação do sistema.

# Visão Geral

O sistema de controle de acesso é baseado em três conceitos fundamentais: Usuários, Perfis e Funcionalidades.

# Usuários
Cada usuário é atribuído a um ou mais perfis, que determinam as permissões do usuário dentro do sistema. O sistema autentica o usuário e verifica suas permissões antes de permitir o acesso a funcionalidades específicas.

# Perfis
Os perfis são conjuntos de permissões que definem quais funcionalidades e métodos um usuário pode acessar. Cada perfil é associado a um ou mais usuários e concede acesso a funcionalidades específicas.

# Funcionalidades
As funcionalidades representam as diferentes partes da aplicação que um usuário pode acessar. Cada funcionalidade pode incluir vários métodos. As permissões de um perfil podem variar de funcionalidade para funcionalidade, permitindo um controle granular do acesso.

# Funcionamento

O funcionamento do sistema é baseado em um middleware que é acionado antes de cada tentativa de execução de um método do sistema. Esse middleware verifica as permissões do usuário no banco de dados com base em seu perfil e na funcionalidade em questão. Se o usuário tiver as permissões necessárias, a execução do método é permitida; caso contrário, o acesso é negado.



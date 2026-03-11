-- Inserir usuários
INSERT INTO usuario (nomeuser, email, senha) 
VALUES 
('João Silva', 'joao.silva@email.com', 'senha123'),
('Maria Oliveira', 'maria.oliveira@email.com', 'senha456'),
('Carlos Souza', 'carlos.souza@email.com', 'senha789'),
('Ana Costa', 'ana.costa@email.com', 'senha321'),
('Pedro Lima', 'pedro.lima@email.com', 'senha654');

-- Inserir categorias
INSERT INTO categorias (nomecategoria) 
VALUES 
('Trabalho'),
('Estudos'),
('Pessoal'),
('Saúde'),
('Financeiro');

-- Inserir notas
INSERT INTO notas (iduser, datanota, titulonota, descricao) 
VALUES 
(1, '2025-05-16 10:00:00', 'Reunião de Projetos', 'Notas sobre a reunião de projetos de TI'),
(2, '2025-05-16 14:00:00', 'Resumo do Capítulo 3', 'Resumo sobre o capítulo 3 de Marketing Digital'),
(3, '2025-05-15 09:00:00', 'Compra de Equipamento', 'Notas sobre a compra de equipamentos para o escritório'),
(4, '2025-05-14 16:30:00', 'Plano de Treinamento', 'Plano de treinamento para a equipe de vendas'),
(5, '2025-05-13 11:45:00', 'Consultoria Financeira', 'Consultoria sobre gestão financeira pessoal');

-- Inserir compartilhamentos
INSERT INTO sharing (notaid, usuarioid, permissao) 
VALUES 
(1, 2, 'Leitura'),
(2, 3, 'Leitura'),
(3, 4, 'Edição'),
(4, 5, 'Leitura'),
(5, 1, 'Edição');

-- Inserir eventos
INSERT INTO evento (tipoevento, descricaoevento) 
VALUES 
('Reunião de Equipe', 'Reunião com toda a equipe para planejamento estratégico'),
('Treinamento Técnico', 'Treinamento sobre novas ferramentas de trabalho'),
('Consulta Médica', 'Consulta com médico especialista para check-up'),
('Palestra Motivacional', 'Palestra sobre produtividade e motivação no trabalho'),
('Workshop Financeiro', 'Workshop sobre gestão financeira e investimentos pessoais');

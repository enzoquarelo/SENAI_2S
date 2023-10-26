USE Veiculos;

INSERT INTO Empresas(nomeEmpresa)
VALUES ('AUTOMOTORS');

INSERT INTO MARCAS(nomeMarca)
VALUES ('Ford'), ('BMW')

INSERT INTO MODELOS(Descricao)
VALUES ('X5'), ('TORO')

INSERT INTO VEICULOS(IdEmpresa, IdMarca, IdModelo, Placa)
VALUES (1, 2, 1, 'ELE6A23')

INSERT INTO CLIENTES(Nome, CPF)
VALUES ('Enzo Quarelo', '49470161831')

INSERT INTO ALUGUEIS(IdCliente, IdVeiculo, DataInicio, DataFim)
VALUES (1, 1, '12-03-2022', '12-05-2022')
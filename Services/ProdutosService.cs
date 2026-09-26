using System;
using System.Collections.Generic;
using System.Linq;
namespace CadastroProdutos.Services;

public class ProdutosService : IProdutosService
{
    private static List<Produto> produtos = new List<Produto>
    {
        new Produto() { Id = 1, Nome = "Mouse", Preco = 70.0m, Estoque = 30 },
        new Produto() { Id = 2, Nome = "Teclado", Preco = 200.0m, Estoque = 20 },
        new Produto() { Id = 3, Nome = "Monitor", Preco = 900.0m, Estoque = 10 },
    };
    public List<Produto> ObterTodos()
    {
        return produtos;
    }

    public Produto ObterPorId(int id)
    {
        return produtos.FirstOrDefault(p => p.Id == id);
    }

    public void Adicionar(Produto novoProduto)
    {
        produtos.Add(novoProduto);
    }

    public Produto Atualizar(int id, Produto produtoAtualizado)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);

        if (produto is null)
        {
            return null;
        }

        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;
        produto.Estoque = produtoAtualizado.Estoque;

        return produto;
    }

    public bool Remover(int id)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);

        if (produto is null)
        {
            return false;
        }

        produtos.Remove(produto);

        return true;
    }
}

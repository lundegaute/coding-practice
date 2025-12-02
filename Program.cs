using CodingPractice.Algorithms;
using CodingPractice.Kata;
using CodingPractice.Objects.Business;
using CodingPractice.DTO;
using CodingPractice.DataSeeds;
using CodingPractice.Api;
using CodingPractice.Models;
using CodingPractice.Yield;
using CodingPractice.Syntax;
using CodingPractice.Trees;


var tree = new Tree();
tree.AddNode(5);
tree.AddNode(3);
tree.AddNode(1);
tree.AddNode(4);
tree.AddNode(2);
tree.AddNode(10);
tree.AddNode(20);
tree.AddNode(19);
tree.AddNode(30);

var ints = tree.InOrderYield(tree.Root);

Console.WriteLine(string.Join(",", ints));
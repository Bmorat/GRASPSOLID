//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe 
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +  // Se utiliza el metodo print de la clase step para imprimir cada paso
                    $"usando '{step.Equipment.Description}' durante {step.Time}");     // de la receta
                
            }  
        }   
    
        //Agregar la responsabilidad de calcular el costo total de producir un producto final:

        public double GetProductionCost() // Se calcula el costo de produccion de la receta
        {
            double totalCost = 0;
            foreach (Step step in this.steps)
            {
                totalCost += step.Input.UnitCost; // Se suma el costo unitario de cada insumo
            }
            foreach (Step step in this.steps)
            {
                totalCost += step.Time * step.Equipment.HourlyCost; // Se suma el costo de cada equipo
            }
            return totalCost;
        }


    
    }
}
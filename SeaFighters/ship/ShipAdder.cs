using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//*********TASK**********
// Переименовать всё к хуям!
// Всё не очевидно называется!

namespace SeaFighters
{
    static class ShipAdder
    {
        /// <summary>
        /// This method is check Cell from CoordinateGenerator method
        /// </summary>
        /// <param name="exectCell"></param>
        /// <param name="verifiablePosition"></param>
        /// <param name="chosenShip"></param>
        /// <returns></returns>
        private static bool PlaceChecker(Cell exectCell, Cell[,] verifiablePosition, Ship chosenShip)
        {
            // veryfication for horizontal ship (by 'j')
            if (chosenShip.IsHorizontal)
            {
                for (int i = (exectCell.Y - 1); i <= (exectCell.Y + 1); i++)
                {
                    for (int j = (exectCell.X - 1); j <= (chosenShip.Size + exectCell.X); j++)
                    {
                        if (verifiablePosition[i, j].state != Cell.Condition.emptyCell &&
                            verifiablePosition[i, j].state != Cell.Condition.emptyBorder ||
                            ((exectCell.X + chosenShip.Size) > (verifiablePosition.GetLength(1) - 1))) { return false; }
                    }
                }
            }

            // veryfication for vertical ship (by 'i')
            else
            {
                for (int i = exectCell.Y - 1; i <= (chosenShip.Size + exectCell.Y); i++)
                {
                    for (int j = exectCell.X - 1; j <= exectCell.X + 1; j++)
                    {
                        if (verifiablePosition[i, j].state != Cell.Condition.emptyCell &&
                            verifiablePosition[i, j].state != Cell.Condition.emptyBorder ||
                            ((exectCell.Y + chosenShip.Size) > (verifiablePosition.GetLength(0) - 1))) { return false; }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// This method is add ship into approved Cell and change neighbor cells from emptyCell to missCell
        /// Presumably this method won't be used.
        /// </summary>
        /// <param name="vertexCell"></param>
        /// <param name="verifiablePosition"></param>
        /// <param name="chosenShip"></param>
        private static void AdderWithNeighborCells(Cell vertexCell, ref Cell[,] verifiablePosition, Ship chosenShip)
        {
            if (chosenShip.IsHorizontal)
            {
                for (int i = vertexCell.Y - 1; i <= vertexCell.Y + 1; i++)
                {
                    for (int j = vertexCell.X - 1; j <= (vertexCell.X + chosenShip.Size); j++)
                    {
                        if ((verifiablePosition[i, j].Y == vertexCell.Y) &&
                            (verifiablePosition[i, j].X > vertexCell.X - 1) &&
                            (verifiablePosition[i, j].X < vertexCell.X + chosenShip.Size))
                        {
                            verifiablePosition[i, j].state = Cell.Condition.fillCell;
                        }
                        else if ((verifiablePosition[i, j].state == Cell.Condition.emptyBorder) ||
                            (verifiablePosition[i, j].state == Cell.Condition.missCell)) { continue; }
                        else { verifiablePosition[i, j].state = Cell.Condition.missCell; }
                    }
                }
            }
            else
            {
                for (int i = vertexCell.Y - 1; i <= (vertexCell.Y + chosenShip.Size); i++)
                {
                    for (int j = vertexCell.X - 1; j <= (vertexCell.X + 1); j++)
                    {
                        if ((verifiablePosition[i, j].X == vertexCell.X) &&
                            (verifiablePosition[i, j].Y > vertexCell.Y - 1) &&
                            (verifiablePosition[i, j].Y < vertexCell.Y + chosenShip.Size))
                        {
                            verifiablePosition[i, j].state = Cell.Condition.fillCell;
                        }
                        else if ((verifiablePosition[i, j].state == Cell.Condition.emptyBorder) ||
                            (verifiablePosition[i, j].state == Cell.Condition.missCell))
                        { continue; }
                        else { verifiablePosition[i, j].state = Cell.Condition.missCell; }
                    }
                }
            }
        }
        
        /// <summary>
        /// This method is add ship in choosen cell.
        /// </summary>
        /// <param name="exectCell"></param>
        /// <param name="verifiablePosition"></param>
        /// <param name="chosenShip"></param>
        private static void Adder(Cell exectCell, ref Cell[,] verifiablePosition, Ship chosenShip)
        {
            if (chosenShip.IsHorizontal)
            {
                for (int i = exectCell.X; i < (exectCell.X + chosenShip.Size); i++)
                {
                    verifiablePosition[exectCell.Y, i].state = Cell.Condition.fillCell;
                }
            }
            else
            {
                for (int i = exectCell.Y; i < (exectCell.Y + chosenShip.Size); i++)
                {
                    verifiablePosition[i, exectCell.X].state = Cell.Condition.fillCell;
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="decomposesField"></param>
        /// <param name="allShips"></param>
        public static void ShipManager(ref Field decomposesField, Shipyard allShips)
            // как сделать, чтобы метод возвращал поле с кораблями, а не принимал по ссылке
        {
            Random R1 = new Random();
            Cell[,] verifiablePosition = decomposesField.WorkField;
            List<Cell> workList = ListCreator(verifiablePosition);
            Cell exactCoordinate;
            int attempt = 0;
            for (int i = 0; i < 10;) // i - shipNumerator
            {
                do
                {
                    exactCoordinate = CoordinateGenerator(ref workList, R1);
                    if (PlaceChecker(exactCoordinate, verifiablePosition, allShips.shipList[i]))
                    {
                        Adder(exactCoordinate, ref verifiablePosition, allShips.shipList[i]);
                        //experemental code
                        //AdderWithNeighborCells(exectCoordinate, ref verifiablePosition, allShips.shipList[i]);
                        //decomposesField.PrintField(); // debugging code
                        i++;
                        break;
                    }
                    else
                    {
                        attempt++;
                        if (attempt > 10000)
                        {
                            decomposesField.Sweeper(ref verifiablePosition);
                            attempt = 0;
                            i = 0;
                            break;
                        }
                        continue;
                    }
                }
                while (true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parsField"></param>
        /// <returns></returns>
        private static List<Cell> ListCreator(Cell[,] parsField)
        {
            List<Cell> CellList = new List<Cell>();
            for (int i = 0; i < (parsField.GetLength(0)); i++)
            {
                for (int j = 0; j < (parsField.GetLength(1)); j++)
                {
                    CellList.Add(parsField[i, j]);
                }
            }
            return CellList;
        }

        /// <summary>
        /// This method is generate accidental coordinates and save them into dictionary
        /// </summary>
        /// <returns>
        /// It's return dictionary with 'x' and 'y' coordinate
        /// </returns>
        private static Cell CoordinateGenerator(ref List<Cell> workList, Random definitelyRandom)
        {
            List<Cell> emptyCellsOnly = ListSweeper(workList);
            
            //calculation accidental index in List of emptyCells
            int assumeVertex = definitelyRandom.Next(0, emptyCellsOnly.Count);
            
            //element with accidental index in List of emptyCells
            return emptyCellsOnly.ElementAt(assumeVertex);
        }

        private static List<Cell> ListSweeper(List<Cell> prepareList)
        {
            int solution = IndexFinder(prepareList);

            while (solution != -1) // because Index couldn't be negative value
            {
                NotEmptyCellDeleter(ref prepareList, solution);
                solution = IndexFinder(prepareList);
            }
            return prepareList;
        }

        private static void NotEmptyCellDeleter(ref List<Cell> prepareList, int indexOfElement)
        {
            prepareList.RemoveAt(indexOfElement);
        }

        private static int IndexFinder(List<Cell> fuckingList)
        {
            int tmp = -1; // because there're no such index in List
            foreach (var i in fuckingList)
            {
                if (i.state != Cell.Condition.emptyCell)
                {
                    tmp = fuckingList.IndexOf(i); // last index of emptyCell element
                }
            }
            return tmp;
        }
    }
}
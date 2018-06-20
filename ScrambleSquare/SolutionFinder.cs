using System;

namespace ScrambleSquare
{
    class SolutionFinder
    {

        private Grid gr;
        private int solutionCount;
        public SolutionFinder(Grid gr)
        {
            this.gr = gr;
        }

        public void FindSolution()
        {
            //TODO: add rotation to check for solutions
            Console.WriteLine("Hey I'm rearrangin' here!");
            int count = gr.TileCount();
            
            bool[] used = new bool[count];
            
            for (int i0 = 0; i0 < count; i0++) if (!used[i0]) //ugh 
                {
                    used[i0] = true;
                    gr.MoveTile(i0 + 1, 0);

                    for (int i1 = 0; i1 < count; i1++) if (!used[i1])
                        {
                            used[i1] = true;
                            gr.MoveTile(i1 + 1, 1);
                            
                            for (int i2 = 0; i2 < count; i2++) if (!used[i2])
                                {
                                    used[i2] = true;
                                    gr.MoveTile(i2 + 1, 2);

                                    for (int i3 = 0; i3 < count; i3++) if (!used[i3])
                                        {
                                            used[i3] = true;
                                            gr.MoveTile(i3 + 1, 3);
                                            
                                            for (int i4 = 0; i4 < count; i4++) if (!used[i4])
                                                {
                                                    used[i4] = true;
                                                    gr.MoveTile(i4 + 1, 4);
                                                    
                                                    for (int i5 = 0; i5 < count; i5++) if (!used[i5])
                                                        {
                                                            used[i5] = true;
                                                            gr.MoveTile(i5 + 1, 5);
                                                            
                                                            for (int i6 = 0; i6 < count; i6++) if (!used[i6])
                                                                {
                                                                    used[i6] = true;
                                                                    gr.MoveTile(i6 + 1, 6);
                                                                    
                                                                    for (int i7 = 0; i7 < count; i7++) if (!used[i7])
                                                                        {
                                                                            used[i7] = true;
                                                                            gr.MoveTile(i7 + 1, 7);

                                                                            for (int i8 = 0; i8 < count; i8++) if (!used[i8])
                                                                                {
                                                                                    used[i8] = true;
                                                                                    gr.MoveTile(i8 + 1, 8);
                                                                                    
                                                                                    if (gr.Valid())
                                                                                    {
                                                                                        SolutionFound();
                                                                                    }

                                                                                    used[i8] = false;
                                                                                }
                                                                            used[i7] = false;
                                                                        }
                                                                    used[i6] = false;
                                                                }
                                                            used[i5] = false;
                                                        }
                                                    used[i4] = false;
                                                }
                                            used[i3] = false;
                                        }
                                    used[i2] = false;
                                }
                            used[i1] = false;
                        }
                    used[i0] = false;
                }
        }

        private void SolutionFound()
        {
            solutionCount++;
            gr.DrawGrid();
        }

        private bool SolutionExists() {
            return solutionCount > 0;
        }

        public void InConclusion() {
            if (SolutionExists())
            {
                Console.WriteLine($"There were {solutionCount} solutions.");
            }
            else
            {
                Console.WriteLine("There were no solutions. Here's the last thing I tried:");
                gr.DrawGrid();
            }
        }
    }
}
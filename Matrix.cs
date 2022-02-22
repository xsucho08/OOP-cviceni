namespace cv03
{
    public class Matrix
    {
        public double[,] aMatrix
        {
            get { return AMatrix; }
            set { AMatrix = value; }
        }
        public double[,] AMatrix;
     

        public Matrix(double[,] aMatrix)
        {
             AMatrix = aMatrix;
        }

        public Matrix()
        {
        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            try
            {

                if (A.AMatrix.GetLength(0) == B.AMatrix.GetLength(0) && A.AMatrix.GetLength(1) == B.AMatrix.GetLength(1))
                {
                    double[,] result;
                    result = new double[A.AMatrix.GetLength(0), A.AMatrix.GetLength(1)];

                    for (int i = 0; i < A.AMatrix.GetLength(1); i++)
                    {
                        for (int j = 0; j < A.AMatrix.GetLength(0); j++)
                        {
                            result[i, j] = A.AMatrix[i, j] + B.AMatrix[i, j];
                        }
                    }
                    return new Matrix(result);
                }

                else
                {
                    throw new ArgumentException("Not possible to add two matrixes of different size.");
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e + "with addition of matrixes");
            }
            return null;
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            try
            {

                if (A.AMatrix.GetLength(0) == B.AMatrix.GetLength(0) && A.AMatrix.GetLength(1) == B.AMatrix.GetLength(1))
                {
                    double[,] result;
                    result = new double[A.AMatrix.GetLength(0), A.AMatrix.GetLength(1)];

                    for (int i = 0; i < A.AMatrix.GetLength(1); i++)
                    {
                        for (int j = 0; j < A.AMatrix.GetLength(0); j++)
                        {
                            result[i, j] = A.AMatrix[i, j] - B.AMatrix[i, j];
                        }
                    }
                    return new Matrix(result);
                }
                else
                {
                    throw new ArgumentException("Not possible to subtracts two matrixes of different size.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e + "with subtraction of matrixes");
            }
            return null;
        }

        public static Matrix operator *(double number, Matrix A)
        {
            try
            {
               double[,] result;
               result = new double[A.AMatrix.GetLength(0), A.AMatrix.GetLength(1)];

                for (int i = 0; i < A.AMatrix.GetLength(1); i++)
                {
                    for (int j = 0; j < A.AMatrix.GetLength(0); j++)
                    {
                        result[i, j] = number * A.AMatrix[i, j];
                    }
                }
                    return new Matrix(result);
                }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e + "with multiplication.");
            }

            return null;
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            try
            {
                if (A.AMatrix.GetLength(1) == B.AMatrix.GetLength(0))
                {
                    double[,] result;
                    result = new double[A.AMatrix.GetLength(0), B.AMatrix.GetLength(1)];

                    for (int i = 0; i < A.AMatrix.GetLength(1); i++)
                    {
                       
                        for (int j = 0; j < B.AMatrix.GetLength(0); j++)
                        {
                            for (int k = 0; k < B.AMatrix.GetLength(1); k++)
                            {
                                result[i, j] = result[i,j] + A.AMatrix[i, k] * B.AMatrix[k, j];    
                            }
                    }
                    }
                    return new Matrix(result);
                }
                else
                {
                    throw new ArgumentException("Not possible to perform multiplication.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e + "with multiplication of matrixes");
            }
            return null;
        }

        public static bool operator ==(Matrix A, Matrix B)
        {
            try
            {
                if (A.AMatrix.GetLength(0) == B.AMatrix.GetLength(0) && A.AMatrix.GetLength(1) == B.AMatrix.GetLength(1))
                {
                    for (int i = 0; i < A.AMatrix.GetLength(1); i++)
                    {
                        for (int j = 0; j < A.AMatrix.GetLength(0); j++)
                        {
                            if (A.AMatrix[i, j] != B.AMatrix[i, j])
                            {
                                return false;
                            }
                                                           
                        }
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e + "with comparison of matrixes");
            }
            return false;
        }

        public static bool operator !=(Matrix A, Matrix B)
        {
            return !(A==B);
        }

        public static Matrix operator -(Matrix A)
        {
            try
            {
                    double[,] result;
                    result = new double[A.AMatrix.GetLength(0), A.AMatrix.GetLength(1)];

                    for (int i = 0; i < A.AMatrix.GetLength(1); i++)
                    {
                        for (int j = 0; j < A.AMatrix.GetLength(0); j++)
                        {
                            result[i, j] = - A.AMatrix[i, j];
                        }
                    }
                return new Matrix(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            return null;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < AMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < AMatrix.GetLength(1); j++)
                {
                    result += string.Format("{0,10:F2}", AMatrix[i, j]);
                }
                result += Environment.NewLine;
            }
            return result;
        }

        public double Determinant()
        {
            try {
                if (AMatrix.GetLength(0) <= 3 && AMatrix.GetLength(1) <= 3 && AMatrix.GetLength(0) == AMatrix.GetLength(1))
                {

                    switch (AMatrix.GetLength(0))
                    {
                        case 1:
                            return AMatrix[0, 0];
                        case 2:
                            return AMatrix[0, 0] * AMatrix[1, 1] - AMatrix[0, 1] * AMatrix[1, 0];
                        case 3:
                            double a = AMatrix[0, 0] * AMatrix[1, 1] * AMatrix[2, 2] - AMatrix[0, 2] * AMatrix[1, 1] * AMatrix[2, 0];
                            double b = AMatrix[1, 0] * AMatrix[2, 1] * AMatrix[0, 2] - AMatrix[1, 2] * AMatrix[2, 1] * AMatrix[0, 0];
                            double c = AMatrix[2, 0] * AMatrix[0, 1] * AMatrix[1, 2] - AMatrix[1, 0] * AMatrix[0, 1] * AMatrix[2, 2];
                            return a + b + c;
                    }
                }
                else
                {
                    throw new ArgumentException("Matrix is not the correct size for this operation.");
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine("Error with computing determinant. Eroor message: " + e);
            }
            return Double.NaN;
        }




    }
}

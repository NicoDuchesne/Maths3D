using System.Numerics;

namespace Maths3D;

public static class MatrixRowReductionAlgorithm
{
    public static (Matrix<T>, Matrix<T>) Apply<T>(Matrix<T> m1, Matrix<T> m2, bool e = false) where T : INumber<T>
    {
        //On construit la matrice augmentée à partir de la matrice transformation m1 et la matrice colonne2 m2 renseignées
        Matrix<T> result = Matrix<T>.GenerateAugmentedMatrix(m1, m2);
        
        int j = 0; // on se place à la première colonne de la matrice, j représentera le pointeur pour les colonnes
        
        //On se place aussi à la premère ligne de la matrice, i représentera le pointeur pour les lignes
        for (int i = 0; i < m1.NbLines; i++) 
        {
            //On prépare les variables pour calculer la valeur max
            int maxIndex = i;
            T maxValue = result[i, j];
            
            //On va parcourir les colonnes col à partir de j
            for (int col = j; col < m1.NbLines; col++)
            {
                maxValue = result[i, j];
                
                for (int k = i+1; k < m1.NbLines; k++) //On va parcourir les lignes k à partir de i+1
                {
                    //Donc, dans chacune des colonnes, on cherche parmi les lignes en dessous de i, l'index de la ligne contenant la plus grande valeur différente de 0
                    if (maxValue == T.Zero && result.MatrixArray[k, j] != T.Zero || result.MatrixArray[k, j] > maxValue && result.MatrixArray[k, j] != T.Zero)
                    {
                        maxIndex = k;
                        maxValue = result.MatrixArray[k, j];
                    } 
                }

                if (maxValue != T.Zero) break; //Dès qu'on trouve cette valeur dans une colonne, on peut sortir de la boucle
                j++;
            }

            //Si on ressort de la boucle sans trouver de nouveau pivot, c'est que toutes les prochaines valeurs sont zero, on ne peut plus toucher à la matrice
            if (maxValue == T.Zero || j >= m1.NbLines)
            {
                if (e) throw new MatrixRowReductionException("Row columns are all zero");
                break;
            }
            
            //Si besoin, on swap avec la ligne contenant la plus grande valeur
            if (maxIndex != i)
            {
                MatrixElementaryOperations.SwapLines(result, i, maxIndex);
            }
            
            //Afin que notre valeur actuelle m(i,j) soit de 1, on multiple notre ligne par son inverse 1/m(i,j)
            if (result.MatrixArray[i, j] != T.Zero)
            {
                MatrixElementaryOperations.MultiplyLine(result, i, T.One/result.MatrixArray[i, j]);
            }
            
            
            //On veut transformer le reste de notre colonne actuelle en 0, on parcourt les autres lignes
            for (int k = 0; k < m1.NbLines; k++)
            {
                if (k != i && result.MatrixArray[k, j] != T.Zero)
                {
                    //Sur chacune des autre ligne k on veut faire : ligne k = ligne k + ( ligne i * -m(k,j) )
                    //Concrètement on transforme les différents m(k,j) en 0 car on sait que notre m(i,j) est maintenant de 1
                    MatrixElementaryOperations.AddLineToAnother(result, i, k, -result.MatrixArray[k, j]);
                }
            }
            
            j++; 
            if (j >= m1.NbLines) break;
        }
            
        
        return result.Split(result.NbColumns-m2.NbColumns-1);//enfin on redécoupe notre matrice augmentée, en ressort la matrice FER et la matrice solution aux équations
    }

    
}
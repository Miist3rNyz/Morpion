using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    public class Jeu
    {
        private Cellule[,] _grille; // Tableau à deux dimensions.

        public Jeu()
        {
            _grille = new Cellule[3, 3]; // Par défaut, le tableau contient des zéros => Cellule.Rien.
        }

        public bool Coche(bool joueur, int i, int j)
        {
            if (_grille[i, j] == Cellule.Rien)
            {
                if (joueur)
                {
                    _grille[i, j] = Cellule.Croix;
                }
                else
                {
                    _grille[i, j] = Cellule.Rond;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Gagnant(out bool joueur)
        {
            Cellule c;

            for (int k = 0; k < 3; k++)
            {
                // Parcours des lignes.
                c = _grille[k, 0];
                if (c != Cellule.Rien && c == _grille[k, 1] && c == _grille[k, 2])
                {
                    joueur = (c == Cellule.Croix);
                    return true;
                }

                // Parcours des colonnes.
                c = _grille[0, k];
                if (c != Cellule.Rien && c == _grille[1, k] && c == _grille[2, k])
                {
                    joueur = (c == Cellule.Croix);
                    return true;
                }
            }

            // Parcours des diagonales.
            c = _grille[0, 0];
            if (c != Cellule.Rien && c == _grille[1, 1] && c == _grille[2, 2])
            {
                joueur = (c == Cellule.Croix);
                return true;
            }

            c = _grille[0, 2];
            if (c != Cellule.Rien && c == _grille[1, 1] && c == _grille[2, 0])
            {
                joueur = (c == Cellule.Croix);
                return true;
            }

            joueur = false; // Valeur arbitraire.
            return false;
        }
    }

    public enum Cellule
    {
        Rien,
        Croix,
        Rond
    }
}

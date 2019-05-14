




function OnGUI()//Lo que aparece en pantalla 
{
    GUILayout.Label( "  Recursos = " + Partida.puntos );

}

function OnTriggerEnter( other : Collider ) {
    if (other.tag == "Recurso")//Si toca el tag "Recurso"  que suba puntos
    {
        Partida.puntos += 1; 
        Destroy(other.gameObject);
        
    }
}





    public static class Partida
    {
        public var puntos=0;  //Puntos por los que comienza
    
    }
	

package exam;

import java.util.ArrayList;

public class Path {
   
    private ArrayList<Square> paths;
    private int value;
    
    public Path(){
        this.paths= new ArrayList<>();
        this.value = 0;
    }
    public Path(Path p){
        this.paths= new ArrayList<>();
        this.value = 0;
        for (int i=0;i<p.size();i++){
            paths.add(p.get(i));
        }
    }
    public void addToValue(int val){
        this.value += val;
    }
    public int getValue(){
        return this.value;
    }
    public void append(Square s){
        paths.add(s);
    }
    public void remove(Square s){
        paths.remove(s);
    }
    public Square get(int i){
        return paths.get(i);
    }
    public Square[] getArray(){
        return (Square[]) paths.toArray();
    }
    public int size(){
        return paths.size();
    }
    @Override
    public String toString(){
        String ret;
        if(paths.size()>0){
            StringBuilder sb= new StringBuilder();
            for(int i=0;i<paths.size()-1;i++){
                sb.append(paths.get(i).toString());
                sb.append(", ");
            }
            sb.append(paths.get(paths.size()-1).toString());
            ret=sb.toString();
        }else{
            ret="Empty path";
        }
        return ret;
    }

}

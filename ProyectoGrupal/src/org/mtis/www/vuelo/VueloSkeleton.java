
/**
 * VueloSkeleton.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.6.3  Built on : Jun 27, 2015 (11:17:49 BST)
 */
    package org.mtis.www.vuelo;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;


/**
     *  VueloSkeleton java skeleton for the axisService
     */
    public class VueloSkeleton{
        
         
        /**
         * Auto generated method signature
         * 
                                     * @param asignarAsiento 
             * @return asignarAsientoResponse 
         */
        
                 public org.mtis.www.vuelo.AsignarAsientoResponse asignarAsiento
                  (
                  org.mtis.www.vuelo.AsignarAsiento asignarAsiento
                  )
            {
                	 Connection con = null;
                   	 AsignarAsientoResponse cu=new AsignarAsientoResponse();
                   	 boolean queryOk = false;
                   	 ResultSet s = null; 
                   	 try
                        {
                             Class.forName("com.mysql.cj.jdbc.Driver");
                             con = DriverManager.getConnection("jdbc:mysql://localhost:3306/companiarea?useUnicode=true&useJDBCCompliantTimezoneShift=true&useLegacyDatetimeCode=false&serverTimezone=UTC","root","adelfr.2000");
                           	 PreparedStatement stmt= con.prepareStatement("select *from cliente where dni='"+asignarAsiento.getDNI()+"';");
                             ResultSet result = stmt.executeQuery();
                             queryOk = result.next();
                             if(queryOk){
                            	 cu.setAsignado(true);
                            	 int ale = (int) (Math.floor(Math.random() * (50 - 1 + 1)) + 1);
                            	 cu.setNumeroAsiento(ale);
                             }
                             else{
                               	 cu.setAsignado(false);
                               	 cu.setNumeroAsiento(-1);
                             }
                            con.close();
                        }
                        catch(Exception e)
                        {
                          
                        }
    					return cu;
        }
     
         
        /**
         * Auto generated method signature
         * 
                                     * @param comprobarFechaLugar 
             * @return comprobarFechaLugarResponse 
         */
        
                 public org.mtis.www.vuelo.ComprobarFechaLugarResponse comprobarFechaLugar
                  (
                  org.mtis.www.vuelo.ComprobarFechaLugar comprobarFechaLugar
                  )
            {
                //TODO : fill this with the necessary business logic
                throw new  java.lang.UnsupportedOperationException("Please implement " + this.getClass().getName() + "#comprobarFechaLugar");
        }
     
         
        /**
         * Auto generated method signature
         * 
                                     * @param comprobarDisponibilidad 
             * @return comprobarDisponibilidadResponse 
         */
        
                 public org.mtis.www.vuelo.ComprobarDisponibilidadResponse comprobarDisponibilidad
                  (
                  org.mtis.www.vuelo.ComprobarDisponibilidad comprobarDisponibilidad
                  )
            {
                //TODO : fill this with the necessary business logic
                throw new  java.lang.UnsupportedOperationException("Please implement " + this.getClass().getName() + "#comprobarDisponibilidad");
        }
     
         
        /**
         * Auto generated method signature
         * 
                                     * @param eliminarAsiento 
             * @return eliminarAsientoResponse 
         */
        
                 public org.mtis.www.vuelo.EliminarAsientoResponse eliminarAsiento
                  (
                  org.mtis.www.vuelo.EliminarAsiento eliminarAsiento
                  )
            {
                //TODO : fill this with the necessary business logic
                throw new  java.lang.UnsupportedOperationException("Please implement " + this.getClass().getName() + "#eliminarAsiento");
        }
     
         
        /**
         * Auto generated method signature
         * 
                                     * @param confirmarAsignacion 
             * @return confirmarAsignacionResponse 
         */
        
                 public org.mtis.www.vuelo.ConfirmarAsignacionResponse confirmarAsignacion
                  (
                  org.mtis.www.vuelo.ConfirmarAsignacion confirmarAsignacion
                  )
            {
                //TODO : fill this with the necessary business logic
                throw new  java.lang.UnsupportedOperationException("Please implement " + this.getClass().getName() + "#confirmarAsignacion");
        }
     
    }
    
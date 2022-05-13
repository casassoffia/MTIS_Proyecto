
/**
 * VueloMessageReceiverInOut.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.6.3  Built on : Jun 27, 2015 (11:17:49 BST)
 */
        package org.mtis.www.vuelo;

        /**
        *  VueloMessageReceiverInOut message receiver
        */

        public class VueloMessageReceiverInOut extends org.apache.axis2.receivers.AbstractInOutMessageReceiver{


        public void invokeBusinessLogic(org.apache.axis2.context.MessageContext msgContext, org.apache.axis2.context.MessageContext newMsgContext)
        throws org.apache.axis2.AxisFault{

        try {

        // get the implementation class for the Web Service
        Object obj = getTheImplementationObject(msgContext);

        VueloSkeleton skel = (VueloSkeleton)obj;
        //Out Envelop
        org.apache.axiom.soap.SOAPEnvelope envelope = null;
        //Find the axisOperation that has been set by the Dispatch phase.
        org.apache.axis2.description.AxisOperation op = msgContext.getOperationContext().getAxisOperation();
        if (op == null) {
        throw new org.apache.axis2.AxisFault("Operation is not located, if this is doclit style the SOAP-ACTION should specified via the SOAP Action to use the RawXMLProvider");
        }

        java.lang.String methodName;
        if((op.getName() != null) && ((methodName = org.apache.axis2.util.JavaUtils.xmlNameToJavaIdentifier(op.getName().getLocalPart())) != null)){


        

            if("asignarAsiento".equals(methodName)){
                
                org.mtis.www.vuelo.AsignarAsientoResponse asignarAsientoResponse21 = null;
	                        org.mtis.www.vuelo.AsignarAsiento wrappedParam =
                                                             (org.mtis.www.vuelo.AsignarAsiento)fromOM(
                                    msgContext.getEnvelope().getBody().getFirstElement(),
                                    org.mtis.www.vuelo.AsignarAsiento.class,
                                    getEnvelopeNamespaces(msgContext.getEnvelope()));
                                                
                                               asignarAsientoResponse21 =
                                                   
                                                   
                                                         skel.asignarAsiento(wrappedParam)
                                                    ;
                                            
                                        envelope = toEnvelope(getSOAPFactory(msgContext), asignarAsientoResponse21, false, new javax.xml.namespace.QName("http://www.mtis.org/Vuelo/",
                                                    "asignarAsiento"));
                                    } else 

            if("comprobarFechaLugar".equals(methodName)){
                
                org.mtis.www.vuelo.ComprobarFechaLugarResponse comprobarFechaLugarResponse23 = null;
	                        org.mtis.www.vuelo.ComprobarFechaLugar wrappedParam =
                                                             (org.mtis.www.vuelo.ComprobarFechaLugar)fromOM(
                                    msgContext.getEnvelope().getBody().getFirstElement(),
                                    org.mtis.www.vuelo.ComprobarFechaLugar.class,
                                    getEnvelopeNamespaces(msgContext.getEnvelope()));
                                                
                                               comprobarFechaLugarResponse23 =
                                                   
                                                   
                                                         skel.comprobarFechaLugar(wrappedParam)
                                                    ;
                                            
                                        envelope = toEnvelope(getSOAPFactory(msgContext), comprobarFechaLugarResponse23, false, new javax.xml.namespace.QName("http://www.mtis.org/Vuelo/",
                                                    "comprobarFechaLugar"));
                                    } else 

            if("comprobarDisponibilidad".equals(methodName)){
                
                org.mtis.www.vuelo.ComprobarDisponibilidadResponse comprobarDisponibilidadResponse25 = null;
	                        org.mtis.www.vuelo.ComprobarDisponibilidad wrappedParam =
                                                             (org.mtis.www.vuelo.ComprobarDisponibilidad)fromOM(
                                    msgContext.getEnvelope().getBody().getFirstElement(),
                                    org.mtis.www.vuelo.ComprobarDisponibilidad.class,
                                    getEnvelopeNamespaces(msgContext.getEnvelope()));
                                                
                                               comprobarDisponibilidadResponse25 =
                                                   
                                                   
                                                         skel.comprobarDisponibilidad(wrappedParam)
                                                    ;
                                            
                                        envelope = toEnvelope(getSOAPFactory(msgContext), comprobarDisponibilidadResponse25, false, new javax.xml.namespace.QName("http://www.mtis.org/Vuelo/",
                                                    "comprobarDisponibilidad"));
                                    } else 

            if("eliminarAsiento".equals(methodName)){
                
                org.mtis.www.vuelo.EliminarAsientoResponse eliminarAsientoResponse27 = null;
	                        org.mtis.www.vuelo.EliminarAsiento wrappedParam =
                                                             (org.mtis.www.vuelo.EliminarAsiento)fromOM(
                                    msgContext.getEnvelope().getBody().getFirstElement(),
                                    org.mtis.www.vuelo.EliminarAsiento.class,
                                    getEnvelopeNamespaces(msgContext.getEnvelope()));
                                                
                                               eliminarAsientoResponse27 =
                                                   
                                                   
                                                         skel.eliminarAsiento(wrappedParam)
                                                    ;
                                            
                                        envelope = toEnvelope(getSOAPFactory(msgContext), eliminarAsientoResponse27, false, new javax.xml.namespace.QName("http://www.mtis.org/Vuelo/",
                                                    "eliminarAsiento"));
                                    } else 

            if("confirmarAsignacion".equals(methodName)){
                
                org.mtis.www.vuelo.ConfirmarAsignacionResponse confirmarAsignacionResponse29 = null;
	                        org.mtis.www.vuelo.ConfirmarAsignacion wrappedParam =
                                                             (org.mtis.www.vuelo.ConfirmarAsignacion)fromOM(
                                    msgContext.getEnvelope().getBody().getFirstElement(),
                                    org.mtis.www.vuelo.ConfirmarAsignacion.class,
                                    getEnvelopeNamespaces(msgContext.getEnvelope()));
                                                
                                               confirmarAsignacionResponse29 =
                                                   
                                                   
                                                         skel.confirmarAsignacion(wrappedParam)
                                                    ;
                                            
                                        envelope = toEnvelope(getSOAPFactory(msgContext), confirmarAsignacionResponse29, false, new javax.xml.namespace.QName("http://www.mtis.org/Vuelo/",
                                                    "confirmarAsignacion"));
                                    
            } else {
              throw new java.lang.RuntimeException("method not found");
            }
        

        newMsgContext.setEnvelope(envelope);
        }
        }
        catch (java.lang.Exception e) {
        throw org.apache.axis2.AxisFault.makeFault(e);
        }
        }
        
        //
            private  org.apache.axiom.om.OMElement  toOM(org.mtis.www.vuelo.AsignarAsiento param, boolean optimizeContent)
            throws org.apache.axis2.AxisFault {

            
                        try{
                             return param.getOMElement(org.mtis.www.vuelo.AsignarAsiento.MY_QNAME,
                                          org.apache.axiom.om.OMAbstractFactory.getOMFactory());
                        } catch(org.apache.axis2.databinding.ADBException e){
                            throw org.apache.axis2.AxisFault.makeFault(e);
                        }
                    

            }
        
            private  org.apache.axiom.om.OMElement  toOM(org.mtis.www.vuelo.AsignarAsientoResponse param, boolean optimizeContent)
            throws org.apache.axis2.AxisFault {

            
                        try{
                             return param.getOMElement(org.mtis.www.vuelo.AsignarAsientoResponse.MY_QNAME,
                                          org.apache.axiom.om.OMAbstractFactory.getOMFactory());
                        } catch(org.apache.axis2.databinding.ADBException e){
                            throw org.apache.axis2.AxisFault.makeFault(e);
                        }
                    

            }
        
            private  org.apache.axiom.om.OMElement  toOM(org.mtis.www.vuelo.ComprobarFechaLugar param, boolean optimizeContent)
            throws org.apache.axis2.AxisFault {

            
                        try{
                             return param.getOMElement(org.mtis.www.vuelo.ComprobarFechaLugar.MY_QNAME,
                                          org.apache.axiom.om.OMAbstractFactory.getOMFactory());
                        } catch(org.apache.axis2.databinding.ADBException e){
                            throw org.apache.axis2.AxisFault.makeFault(e);
                        }
                    

            }
        
            private  org.apache.axiom.om.OMElement  toOM(org.mtis.www.vuelo.ComprobarFechaLugarResponse param, boolean optimizeContent)
            throws org.apache.axis2.AxisFault {

            
                        try{
                             return param.getOMElement(org.mtis.www.vuelo.ComprobarFechaLugarResponse.MY_QNAME,
                                          org.apache.axiom.om.OMAbstractFactory.getOMFactory());
                        } catch(org.apache.axis2.databinding.ADBException e){
                            throw org.apache.axis2.AxisFault.makeFault(e);
                        }
                    

            }
        
            private  org.apache.axiom.om.OMElement  toOM(org.mtis.www.vuelo.ComprobarDisponibilidad param, boolean optimizeContent)
            throws org.apache.axis2.AxisFault {

            
                        try{
                             return param.getOMElement(org.mtis.www.vuelo.ComprobarDisponibilidad.MY_QNAME,
                                          org.apache.axiom.om.OMAbstractFactory.getOMFactory());
                        } catch(org.apache.axis2.databinding.ADBException e){
                            throw org.apache.axis2.AxisFault.makeFault(e);
                        }
                    

            }
        
            private  org.apache.axiom.om.OMElement  toOM(org.mtis.www.vuelo.ComprobarDisponibilidadResponse param, boolean optimizeContent)
            throws org.apache.axis2.AxisFault {

            
                        try{
                             return param.getOMElement(org.mtis.www.vuelo.ComprobarDisponibilidadResponse.MY_QNAME,
                                          org.apache.axiom.om.OMAbstractFactory.getOMFactory());
                        } catch(org.apache.axis2.databinding.ADBException e){
                            throw org.apache.axis2.AxisFault.makeFault(e);
                        }
                    

            }
        
            private  org.apache.axiom.om.OMElement  toOM(org.mtis.www.vuelo.EliminarAsiento param, boolean optimizeContent)
            throws org.apache.axis2.AxisFault {

            
                        try{
                             return param.getOMElement(org.mtis.www.vuelo.EliminarAsiento.MY_QNAME,
                                          org.apache.axiom.om.OMAbstractFactory.getOMFactory());
                        } catch(org.apache.axis2.databinding.ADBException e){
                            throw org.apache.axis2.AxisFault.makeFault(e);
                        }
                    

            }
        
            private  org.apache.axiom.om.OMElement  toOM(org.mtis.www.vuelo.EliminarAsientoResponse param, boolean optimizeContent)
            throws org.apache.axis2.AxisFault {

            
                        try{
                             return param.getOMElement(org.mtis.www.vuelo.EliminarAsientoResponse.MY_QNAME,
                                          org.apache.axiom.om.OMAbstractFactory.getOMFactory());
                        } catch(org.apache.axis2.databinding.ADBException e){
                            throw org.apache.axis2.AxisFault.makeFault(e);
                        }
                    

            }
        
            private  org.apache.axiom.om.OMElement  toOM(org.mtis.www.vuelo.ConfirmarAsignacion param, boolean optimizeContent)
            throws org.apache.axis2.AxisFault {

            
                        try{
                             return param.getOMElement(org.mtis.www.vuelo.ConfirmarAsignacion.MY_QNAME,
                                          org.apache.axiom.om.OMAbstractFactory.getOMFactory());
                        } catch(org.apache.axis2.databinding.ADBException e){
                            throw org.apache.axis2.AxisFault.makeFault(e);
                        }
                    

            }
        
            private  org.apache.axiom.om.OMElement  toOM(org.mtis.www.vuelo.ConfirmarAsignacionResponse param, boolean optimizeContent)
            throws org.apache.axis2.AxisFault {

            
                        try{
                             return param.getOMElement(org.mtis.www.vuelo.ConfirmarAsignacionResponse.MY_QNAME,
                                          org.apache.axiom.om.OMAbstractFactory.getOMFactory());
                        } catch(org.apache.axis2.databinding.ADBException e){
                            throw org.apache.axis2.AxisFault.makeFault(e);
                        }
                    

            }
        
                    private  org.apache.axiom.soap.SOAPEnvelope toEnvelope(org.apache.axiom.soap.SOAPFactory factory, org.mtis.www.vuelo.AsignarAsientoResponse param, boolean optimizeContent, javax.xml.namespace.QName methodQName)
                        throws org.apache.axis2.AxisFault{
                      try{
                          org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory.getDefaultEnvelope();
                           
                                    emptyEnvelope.getBody().addChild(param.getOMElement(org.mtis.www.vuelo.AsignarAsientoResponse.MY_QNAME,factory));
                                

                         return emptyEnvelope;
                    } catch(org.apache.axis2.databinding.ADBException e){
                        throw org.apache.axis2.AxisFault.makeFault(e);
                    }
                    }
                    
                         private org.mtis.www.vuelo.AsignarAsientoResponse wrapasignarAsiento(){
                                org.mtis.www.vuelo.AsignarAsientoResponse wrappedElement = new org.mtis.www.vuelo.AsignarAsientoResponse();
                                return wrappedElement;
                         }
                    
                    private  org.apache.axiom.soap.SOAPEnvelope toEnvelope(org.apache.axiom.soap.SOAPFactory factory, org.mtis.www.vuelo.ComprobarFechaLugarResponse param, boolean optimizeContent, javax.xml.namespace.QName methodQName)
                        throws org.apache.axis2.AxisFault{
                      try{
                          org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory.getDefaultEnvelope();
                           
                                    emptyEnvelope.getBody().addChild(param.getOMElement(org.mtis.www.vuelo.ComprobarFechaLugarResponse.MY_QNAME,factory));
                                

                         return emptyEnvelope;
                    } catch(org.apache.axis2.databinding.ADBException e){
                        throw org.apache.axis2.AxisFault.makeFault(e);
                    }
                    }
                    
                         private org.mtis.www.vuelo.ComprobarFechaLugarResponse wrapcomprobarFechaLugar(){
                                org.mtis.www.vuelo.ComprobarFechaLugarResponse wrappedElement = new org.mtis.www.vuelo.ComprobarFechaLugarResponse();
                                return wrappedElement;
                         }
                    
                    private  org.apache.axiom.soap.SOAPEnvelope toEnvelope(org.apache.axiom.soap.SOAPFactory factory, org.mtis.www.vuelo.ComprobarDisponibilidadResponse param, boolean optimizeContent, javax.xml.namespace.QName methodQName)
                        throws org.apache.axis2.AxisFault{
                      try{
                          org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory.getDefaultEnvelope();
                           
                                    emptyEnvelope.getBody().addChild(param.getOMElement(org.mtis.www.vuelo.ComprobarDisponibilidadResponse.MY_QNAME,factory));
                                

                         return emptyEnvelope;
                    } catch(org.apache.axis2.databinding.ADBException e){
                        throw org.apache.axis2.AxisFault.makeFault(e);
                    }
                    }
                    
                         private org.mtis.www.vuelo.ComprobarDisponibilidadResponse wrapcomprobarDisponibilidad(){
                                org.mtis.www.vuelo.ComprobarDisponibilidadResponse wrappedElement = new org.mtis.www.vuelo.ComprobarDisponibilidadResponse();
                                return wrappedElement;
                         }
                    
                    private  org.apache.axiom.soap.SOAPEnvelope toEnvelope(org.apache.axiom.soap.SOAPFactory factory, org.mtis.www.vuelo.EliminarAsientoResponse param, boolean optimizeContent, javax.xml.namespace.QName methodQName)
                        throws org.apache.axis2.AxisFault{
                      try{
                          org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory.getDefaultEnvelope();
                           
                                    emptyEnvelope.getBody().addChild(param.getOMElement(org.mtis.www.vuelo.EliminarAsientoResponse.MY_QNAME,factory));
                                

                         return emptyEnvelope;
                    } catch(org.apache.axis2.databinding.ADBException e){
                        throw org.apache.axis2.AxisFault.makeFault(e);
                    }
                    }
                    
                         private org.mtis.www.vuelo.EliminarAsientoResponse wrapeliminarAsiento(){
                                org.mtis.www.vuelo.EliminarAsientoResponse wrappedElement = new org.mtis.www.vuelo.EliminarAsientoResponse();
                                return wrappedElement;
                         }
                    
                    private  org.apache.axiom.soap.SOAPEnvelope toEnvelope(org.apache.axiom.soap.SOAPFactory factory, org.mtis.www.vuelo.ConfirmarAsignacionResponse param, boolean optimizeContent, javax.xml.namespace.QName methodQName)
                        throws org.apache.axis2.AxisFault{
                      try{
                          org.apache.axiom.soap.SOAPEnvelope emptyEnvelope = factory.getDefaultEnvelope();
                           
                                    emptyEnvelope.getBody().addChild(param.getOMElement(org.mtis.www.vuelo.ConfirmarAsignacionResponse.MY_QNAME,factory));
                                

                         return emptyEnvelope;
                    } catch(org.apache.axis2.databinding.ADBException e){
                        throw org.apache.axis2.AxisFault.makeFault(e);
                    }
                    }
                    
                         private org.mtis.www.vuelo.ConfirmarAsignacionResponse wrapconfirmarAsignacion(){
                                org.mtis.www.vuelo.ConfirmarAsignacionResponse wrappedElement = new org.mtis.www.vuelo.ConfirmarAsignacionResponse();
                                return wrappedElement;
                         }
                    


        /**
        *  get the default envelope
        */
        private org.apache.axiom.soap.SOAPEnvelope toEnvelope(org.apache.axiom.soap.SOAPFactory factory){
        return factory.getDefaultEnvelope();
        }


        private  java.lang.Object fromOM(
        org.apache.axiom.om.OMElement param,
        java.lang.Class type,
        java.util.Map extraNamespaces) throws org.apache.axis2.AxisFault{

        try {
        
                if (org.mtis.www.vuelo.AsignarAsiento.class.equals(type)){
                
                        return org.mtis.www.vuelo.AsignarAsiento.Factory.parse(param.getXMLStreamReaderWithoutCaching());
                    

                }
            
                if (org.mtis.www.vuelo.AsignarAsientoResponse.class.equals(type)){
                
                        return org.mtis.www.vuelo.AsignarAsientoResponse.Factory.parse(param.getXMLStreamReaderWithoutCaching());
                    

                }
            
                if (org.mtis.www.vuelo.ComprobarDisponibilidad.class.equals(type)){
                
                        return org.mtis.www.vuelo.ComprobarDisponibilidad.Factory.parse(param.getXMLStreamReaderWithoutCaching());
                    

                }
            
                if (org.mtis.www.vuelo.ComprobarDisponibilidadResponse.class.equals(type)){
                
                        return org.mtis.www.vuelo.ComprobarDisponibilidadResponse.Factory.parse(param.getXMLStreamReaderWithoutCaching());
                    

                }
            
                if (org.mtis.www.vuelo.ComprobarFechaLugar.class.equals(type)){
                
                        return org.mtis.www.vuelo.ComprobarFechaLugar.Factory.parse(param.getXMLStreamReaderWithoutCaching());
                    

                }
            
                if (org.mtis.www.vuelo.ComprobarFechaLugarResponse.class.equals(type)){
                
                        return org.mtis.www.vuelo.ComprobarFechaLugarResponse.Factory.parse(param.getXMLStreamReaderWithoutCaching());
                    

                }
            
                if (org.mtis.www.vuelo.ConfirmarAsignacion.class.equals(type)){
                
                        return org.mtis.www.vuelo.ConfirmarAsignacion.Factory.parse(param.getXMLStreamReaderWithoutCaching());
                    

                }
            
                if (org.mtis.www.vuelo.ConfirmarAsignacionResponse.class.equals(type)){
                
                        return org.mtis.www.vuelo.ConfirmarAsignacionResponse.Factory.parse(param.getXMLStreamReaderWithoutCaching());
                    

                }
            
                if (org.mtis.www.vuelo.EliminarAsiento.class.equals(type)){
                
                        return org.mtis.www.vuelo.EliminarAsiento.Factory.parse(param.getXMLStreamReaderWithoutCaching());
                    

                }
            
                if (org.mtis.www.vuelo.EliminarAsientoResponse.class.equals(type)){
                
                        return org.mtis.www.vuelo.EliminarAsientoResponse.Factory.parse(param.getXMLStreamReaderWithoutCaching());
                    

                }
            
        } catch (java.lang.Exception e) {
        throw org.apache.axis2.AxisFault.makeFault(e);
        }
           return null;
        }



    

        /**
        *  A utility method that copies the namepaces from the SOAPEnvelope
        */
        private java.util.Map getEnvelopeNamespaces(org.apache.axiom.soap.SOAPEnvelope env){
        java.util.Map returnMap = new java.util.HashMap();
        java.util.Iterator namespaceIterator = env.getAllDeclaredNamespaces();
        while (namespaceIterator.hasNext()) {
        org.apache.axiom.om.OMNamespace ns = (org.apache.axiom.om.OMNamespace) namespaceIterator.next();
        returnMap.put(ns.getPrefix(),ns.getNamespaceURI());
        }
        return returnMap;
        }

        private org.apache.axis2.AxisFault createAxisFault(java.lang.Exception e) {
        org.apache.axis2.AxisFault f;
        Throwable cause = e.getCause();
        if (cause != null) {
            f = new org.apache.axis2.AxisFault(e.getMessage(), cause);
        } else {
            f = new org.apache.axis2.AxisFault(e.getMessage());
        }

        return f;
    }

        }//end of class
    
<?xml version="1.0"?>
<xsl:stylesheet	version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="no"/>
  <xsl:param name="CurrentURL"></xsl:param>
  <xsl:param name="CurrentURLShort"></xsl:param>
  <xsl:param name="Home"></xsl:param>
  <xsl:param name="ID"></xsl:param>

  <xsl:template match="item">
    <table>
      <tr>
        <xsl:if test="descendant-or-self::*[@id=$ID]">
          <xsl:for-each select="self::*">
            <td>
              <div class="LeftNav">
              <b>
                <a>
					<xsl:attribute name="onclick">javascript:return PromptToDiscardChanges();</xsl:attribute>
					<xsl:attribute name="href">
						<xsl:value-of select="$Home" />
						<xsl:value-of select="@url"/>
                    </xsl:attribute>
                  <xsl:value-of select="@name"/>
                </a>
              </b>
            </div>
            </td>
            <xsl:call-template name="buildChildren"></xsl:call-template>
          </xsl:for-each>
        </xsl:if>
      </tr>
    </table>
  </xsl:template>

  <xsl:template name="buildChildren">
      <xsl:for-each select="child::*">
        <xsl:if test="descendant-or-self::*[@id = $ID]">
          <td>
            <div class="LeftNav">
              <b>
                |
              </b>
            </div>
          </td>
          <td>
            <div class="LeftNav">
              <b>
                <a>
                  <xsl:if test="count(child::*) > 0">
					  <xsl:attribute name="onclick">javascript:return PromptToDiscardChanges();</xsl:attribute>
					  <xsl:attribute name="href">
						  <xsl:value-of select="$Home" />
						  <xsl:value-of select="@url"/>
					  </xsl:attribute>
                    <xsl:value-of select="@name"/>
                  </xsl:if>
                  <xsl:if test="count(child::*) = 0">
					  <xsl:attribute name="onclick">javascript:return PromptToDiscardChanges();</xsl:attribute>
					  <xsl:attribute name="href">
						  <xsl:value-of select="$Home" />
						  <xsl:value-of select="$CurrentURL"/>
                      </xsl:attribute>
                    <xsl:value-of select="@name"/>
                  </xsl:if>
                </a>
              </b>
            </div>
          </td>
              <xsl:call-template name="buildChildren"></xsl:call-template>
        </xsl:if>
      </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>